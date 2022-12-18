import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccsesLevel } from 'src/types/AccsesLevelType';
import { ClaimTypes } from 'src/types/ClaimTypes';
import { UsersApiService } from './services/api/users.api/users.api.service';
import { AuthService } from './services/api/auth/auth.service';
import { StorageService } from './services/storage/storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SchoolSystem';

  constructor(private api: UsersApiService, private router: Router, private storage: StorageService, private auth: AuthService) { }

  ngOnInit(): void {
    this.api.isFirstStart().then(x => {
      if (x) {
        this.router.navigate(['/start']);
      }
    });
    this.auth.user().subscribe(res => {
      if (res.success) {
        this.storage.accsesLevel = res.data!.find(p => p.type == ClaimTypes.Role)?.value as AccsesLevel;
        if(location.pathname == '/'){
          this.router.navigate(['/home']);
        }
      }
    });
  }

}
