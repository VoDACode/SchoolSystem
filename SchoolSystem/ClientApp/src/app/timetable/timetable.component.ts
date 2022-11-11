import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Lesson } from 'src/models/LessonModel';
import { ModalService } from '../_modal';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements AfterViewInit{

  @ViewChild('timesElement') timesElement: ElementRef<HTMLDivElement> | undefined = undefined;
  @ViewChild('main') mainElement: ElementRef<HTMLDivElement> | undefined = undefined;

  days:{day:string, month:string, num:string}[] = [];

  times: string[] = [];
  
  lessons: Lesson[] = [];

  detailsItem: Lesson = new Lesson(0, '', '', '', new Date(), 0, 0, 0, 0);

  constructor(private modalService: ModalService) {
    let days = ['Пн','Вт','Ср','Чт','Пт','Сб','Нд'];
    let date = new Date();
    let monday = date.getDate() - date.getDay() + 1;
    for (let i = 0; i < 6; i++) {
      let newDate = new Date(date.setDate(monday + i));
      this.days.push({
        day: days[i],
        month: this.addNull(newDate.getMonth() + 1),
        num: this.addNull(newDate.getDate())
      });
    }

    for(let i = 1; i <= 8; i++){
      this.times.push(`${i}-й урок`);
    }

    let startTime = new Date();
    startTime.setHours(8);
    startTime.setMinutes(25);
    startTime.setSeconds(0);
    date = new Date();
    date.setDate(7);
    this.lessons.push(new Lesson(1, 'Математика', 'Іванов І.І.', '101', date, 1, startTime.getTime()/1000, 45, 5));
  }
  ngAfterViewInit(): void {
    let items = document.getElementsByClassName('grid');
    for(let i = 0; i < items.length; i++){
      items[i].setAttribute('style', `height: ${this.timesElement?.nativeElement.offsetHeight}px`);
    }
    this.mainElement?.nativeElement.setAttribute(
      'style', 
      `height: ${(this.mainElement?.nativeElement.offsetHeight || 0) + (this.timesElement?.nativeElement.offsetHeight || 0)}px`
      );
  }

  showDetails(lesson: Lesson): void {
    this.detailsItem = lesson;
    this.modalService.open('lesson-details');
  }

  addNull(num: number): string {
    return num < 10 ? `0${num}` : `${num}`;
  }
}
