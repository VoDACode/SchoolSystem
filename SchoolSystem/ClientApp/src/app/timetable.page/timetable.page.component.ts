import { Component, OnInit } from '@angular/core';
import { AccsesLevel } from 'src/types/AccsesLevelType';
import { StorageService } from '../services/storage.service';

@Component({
  selector: 'app-timetable.page',
  templateUrl: './timetable.page.component.html',
  styleUrls: ['./timetable.page.component.css']
})
export class TimetablePageComponent implements OnInit {

  get accsesLevel(): AccsesLevel {
    return this.storage.accsesLevel;
  }

  editMode: boolean = false;

  constructor(private storage: StorageService) { }

  ngOnInit(): void {
  }

}
