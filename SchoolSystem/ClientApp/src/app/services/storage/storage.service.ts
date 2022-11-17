import { Injectable } from '@angular/core';
import { AccsesLevel } from 'src/types/AccsesLevelType';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private static _accsesLevel: AccsesLevel = 'ADMIN';

  constructor() {
    StorageService._accsesLevel = localStorage.getItem('accsesLevel') as AccsesLevel;
  }

  get accsesLevel(): AccsesLevel {
    return StorageService._accsesLevel;
  }

  set accsesLevel(value: AccsesLevel) {
    StorageService._accsesLevel = value;
    localStorage.setItem('accsesLevel', value);
  }

  public clear(): void {
    localStorage.clear();
  }
}
