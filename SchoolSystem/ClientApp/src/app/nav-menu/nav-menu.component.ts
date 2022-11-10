import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavItem } from 'src/models/NavItem';
import { StorageService } from '../services/storage.service';

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
      new NavItem('Головна', true, 'home' ,'/home'),
      new NavItem('Успішність', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'stats', '/my/stats'),
      new NavItem('Домашні завдання', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'homework', '/my/homework'),
      new NavItem('Розклад', true, 'schedule', '/schedule'),
      new NavItem('Повідомлення', true, 'message', '/my/message'),
      new NavItem('Вчитклі', storage.accsesLevel == 'STUDENT' || storage.accsesLevel == 'PARENT', 'teacher', '/my/teacher'),
      new NavItem('Дисципліни', storage.accsesLevel == 'TEACHER', 'discipline', '/discipline'),
      new NavItem('Класи', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'group', '/my/group'),
      new NavItem('Домашні завдання', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'homework', '/my/homework'),
      new NavItem('План занять', storage.accsesLevel == 'TEACHER' || storage.accsesLevel == 'ADMIN', 'plan', '/my/plan'),
      new NavItem('Користувачі', storage.accsesLevel == 'ADMIN', 'user', '/my/user'),
      new NavItem('Дисципліни', storage.accsesLevel == 'ADMIN', 'discipline', '/discipline'),
      new NavItem('Довідки', true, 'reference', '/reference'),
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
