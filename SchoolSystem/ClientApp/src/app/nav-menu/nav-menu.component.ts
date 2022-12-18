import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavItem } from 'src/models/NavItem';
import { StorageService } from '../services/storage/storage.service';

@Component({
  selector: 'app-nav-menu',
  animations: [
    trigger('openClose', [
      state('open', style({
        left: 0,
        opacity: 1,
      })),
      state('closed', style({
        left: '-300px',
        opacity: 0.5,
      })),
      transition('open => closed', [
        animate('0.5s')
      ]),
      transition('closed => open', [
        animate('0.5s')
      ]),
    ]),
  ],
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  @ViewChild('openMenuButton') elementOpenMenuButton: ElementRef<HTMLImageElement> | undefined;

  public isOpen = false;

  private _navigation: NavItem[] = [];

  get navigation(): NavItem[] {
    return this._navigation.filter(x => x.disabled);
  }

  constructor(public storage: StorageService) {
    this._navigation = [
      new NavItem('Головна', true, 'icons8-home-page-48.png' ,'/home'),
      new NavItem('Успішність', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'icons8-analytics-48.png', '/my/stats'),
      new NavItem('Домашні завдання', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'icons8-homework-40.png', '/my/homework'),
      new NavItem('Розклад', true, 'icons8-gantt-chart-48.png', '/timetable'),
      new NavItem('Повідомлення', true, 'icons8-chat-message-48.png', '/my/message'),
      new NavItem('Вчителі', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'icons8-training-48.png', '/my/teacher'),
      new NavItem('Предмети', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'icons8-discipline-64.png', '/discipline-editor'),
      new NavItem('Класи', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'icons8-groups-64.png', '/my/groups'),
      new NavItem('План занять', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'icons8-what-i-do-48.png', '/my/plan'),
      new NavItem('Користувачі', storage.accsesLevel == 'ADMIN', 'icons8-people-48.png', '/users'),
      new NavItem('Довідки', true, 'icons8-reference-64.png', '/reference'),
    ];
  }

  closeMenu(){
    this.isOpen = false;
  }

  toggle(): void {
    this.isOpen = !this.isOpen;
    
    if (this.isOpen) {
      //@ts-ignore
      this.elementOpenMenuButton?.nativeElement.src = 'assets\\images\\open-menu.gif';
      setTimeout(() => {
        //@ts-ignore
        this.elementOpenMenuButton?.nativeElement.src = 'assets\\images\\close-menu.png';
      }, 500);
    } else {
      //@ts-ignore
      this.elementOpenMenuButton?.nativeElement.src = 'assets\\images\\close-menu.gif';
      setTimeout(() => {
        //@ts-ignore
        this.elementOpenMenuButton?.nativeElement.src = 'assets\\images\\open-menu.png';
      }, 500);
    }
  }
}
