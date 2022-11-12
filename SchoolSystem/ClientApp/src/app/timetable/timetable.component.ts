import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Lesson } from 'src/models/LessonModel';
import { ModalService } from '../_modal';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements AfterViewInit {

  @Input()
  editMode: boolean = false;

  @ViewChild('timesElement') timesElement: ElementRef<HTMLDivElement> | undefined = undefined;
  @ViewChild('main') mainElement: ElementRef<HTMLDivElement> | undefined = undefined;

  days: { day: string, month: string, num: string }[] = [];

  times: string[] = [];

  private _lessons: Lesson[] = [];

  monday: Date = new Date();

  today: Date = new Date();

  get lessons(): Lesson[] {
    if (this.editMode)
      return this._lessons;
    else
      return this._lessons.filter(p => p.id > 0);
  }

  detailsItem: Lesson = new Lesson(0, '', '', '', new Date(), 0, 0, 0, 0);

  constructor(private modalService: ModalService) {
    let date = new Date();
    date.setHours(0, 0, 0, 0);
    this.monday = new Date(date.setDate(date.getDate() - date.getDay() + 1));
    this.geterateDays();

    for (let i = 1; i <= 8; i++) {
      this.times.push(`${i}-й урок`);
    }

    this.getTimetable();
  }

  ngAfterViewInit(): void {
    let items = document.getElementsByClassName('grid');
    for (let i = 0; i < items.length; i++) {
      items[i].setAttribute('style', `height: ${this.timesElement?.nativeElement.offsetHeight}px`);
    }
    this.mainElement?.nativeElement.setAttribute(
      'style',
      `height: ${(this.mainElement?.nativeElement.offsetHeight || 0) + (this.timesElement?.nativeElement.offsetHeight || 0)}px`
    );
  }

  showDetails(lesson: Lesson): void {
    if (lesson.id < 0)
      return;
    this.detailsItem = lesson;
    this.modalService.open('lesson-details');
  }

  addNewItem(lesson: Lesson): void {
    this.detailsItem = lesson;
    this.modalService.open('lesson-details');
  }

  closeMadal(): void {
    this.detailsItem = new Lesson(0, '', '', '', new Date(), 0, 0, 0, 0);
  }

  nextWeek(): void {
    this.monday.setDate(this.monday.getDate() + 7);
    this.geterateDays();
  }

  prevWeek(): void {
    this.monday.setDate(this.monday.getDate() - 7);
    this.geterateDays();
  }

  geterateDays() {
    let days = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'];
    this.days.length = 0;
    for (let i = 0; i < 6; i++) {
      let newDate = new Date(this.monday);
      newDate.setDate(this.monday.getDate() + i);
      this.days.push({
        day: days[i],
        month: this.addNull(newDate.getMonth() + 1),
        num: this.addNull(newDate.getDate())
      });
    }
    setTimeout(() => {
      let items = document.getElementsByClassName('grid');
      if (items.length > 0) {
        for (let i = 0; i < items.length; i++) {
          items[i].setAttribute('style', `height: ${this.timesElement?.nativeElement.offsetHeight}px`);
        }
      }
    }, 1);
  }

  getTimetable(): void {
    //TODO: add support for server
    let startTime = new Date();
    startTime.setHours(8);
    startTime.setMinutes(25);
    startTime.setSeconds(0);
    let date = new Date();
    date.setDate(7);
    this._lessons.push(new Lesson(1, 'Математика', 'Іванов І.І.', '101', date, 1, startTime.getTime() / 1000, 45, 5));

    // Fill empty lessons
    for (let x = 0; x < 6; x++) {
      for (let y = 1; y <= 8; y++) {
        let date = new Date();
        date.setDate(this.monday.getDate() + x);
        let item = this._lessons.find(p => p.day.getDate() == date.getDate() && p.day.getMonth() == date.getMonth() && p.lesson == y);
        if (item == undefined) {
          this._lessons.push(new Lesson(-1, '', '', '', date, y, 0, 0, 0));
        }
      }
    }
  }


  saveLesson(): void {
    let item = this._lessons.find(
      p => p.day.getMonth() == this.detailsItem.day.getMonth()
        && p.day.getDate() == this.detailsItem.day.getDate() && p.lesson == this.detailsItem.lesson);
    if (!!item) {
      // TODO: save lesson to db then get id and change model parameters
      item.id = 5;
      item.name = this.detailsItem.name;
      item.teacher = this.detailsItem.teacher;
      item.room = this.detailsItem.room;
      item.duration = this.detailsItem.duration;
      item.group = this.detailsItem.group;
      this.modalService.close('lesson-details');
      this.closeMadal();
    }
  }

  deleteLesson(): void {
    // TODO: delete lesson from db
    this._lessons.find(p => p.id == this.detailsItem.id)!.duration = 0;
    this._lessons.find(p => p.id == this.detailsItem.id)!.group = 0;
    this._lessons.find(p => p.id == this.detailsItem.id)!.name = '';
    this._lessons.find(p => p.id == this.detailsItem.id)!.room = '';
    this._lessons.find(p => p.id == this.detailsItem.id)!.teacher = '';
    this._lessons.find(p => p.id == this.detailsItem.id)!.id = -1;
    this.modalService.close('lesson-details');
    this.closeMadal();
  }

  addNull(num: number): string {
    return num < 10 ? `0${num}` : `${num}`;
  }
}
