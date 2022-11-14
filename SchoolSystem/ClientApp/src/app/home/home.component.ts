import { StorageService } from '../services/storage/storage.service';
import { Component, OnInit } from '@angular/core';
import { AccsesLevel } from 'src/types/AccsesLevelType';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  get accsesLevel(): AccsesLevel {
    return this._storage.accsesLevel;
  }

  constructor(private _storage: StorageService) { }

  ngOnInit(): void {
  }

}
