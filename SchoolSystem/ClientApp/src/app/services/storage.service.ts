import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private static _accsesLevel: 'ADMIN' | 'TEACHER' | 'STUDENT' = 'STUDENT';

  constructor() { }

  get accsesLevel(): 'ADMIN' | 'TEACHER' | 'STUDENT' {
    return StorageService._accsesLevel;
  }

  set accsesLevel(value: 'ADMIN' | 'TEACHER' | 'STUDENT') {
    StorageService._accsesLevel = value;
  }
}
