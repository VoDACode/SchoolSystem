import { StorageService } from './../services/storage.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  get accsesLevel(): 'ADMIN' | 'TEACHER' | 'STUDENT' {
    return this._storage.accsesLevel;
  }

  constructor(private _storage: StorageService) { }

  ngOnInit(): void {
  }

}
