import { Injectable } from '@angular/core';
import { AccsesLevel } from 'src/types/AccsesLevelType';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private static _accsesLevel: AccsesLevel = 'PARENT';

  constructor() { }

  get accsesLevel(): AccsesLevel {
    return StorageService._accsesLevel;
  }

  set accsesLevel(value: AccsesLevel) {
    StorageService._accsesLevel = value;
  }
}
