import { StorageService } from './../services/storage/storage.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private router: Router, private storage: StorageService) { }

  ngOnInit(): void {
  }

  logout(): void {
    fetch('/api/account/logout', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(response => {
      if (response.status === 200) {
        this.router.navigate(['auth', 'login']);
        this.storage.clear();
      }
    }).catch(error => {
      if (environment.debug) {
        console.error(`Logout failed: ${error}`);
      }
    });
  }

}
