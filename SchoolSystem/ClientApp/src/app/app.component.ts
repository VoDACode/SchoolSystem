import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from './services/api/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SchoolSystem';

  constructor(private api: ApiService, private router: Router) {
  }

  ngOnInit(): void {
    this.api.isFirstStart().then(x => {
      if (x == false) {
        this.router.navigate(['/start']);
      }
    });
  }

}
