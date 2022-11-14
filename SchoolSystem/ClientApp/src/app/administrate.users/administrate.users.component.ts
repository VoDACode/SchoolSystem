import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/UserModel';
import { ApiService } from '../services/api/api.service';
import { StorageService } from '../services/storage/storage.service';

@Component({
  selector: 'app-administrate.users',
  templateUrl: './administrate.users.component.html',
  styleUrls: ['./administrate.users.component.css']
})
export class AdministrateUsersComponent implements OnInit {

  users: User[] = [];

  newUser: User = new User('', '', '', '', '', '', '', 'STUDENT', false, new Date(), new Date());

  constructor(private router: Router, private storage: StorageService, private api: ApiService) { }

  ngOnInit(): void {
    if (this.storage.accsesLevel != 'ADMIN') {
      this.router.navigate(['/home']);
    }else{
      this.api.getUsers().then(x => {
        this.users = x
      });
    }
  }

  viewPassword(user: User): void {
    this.api.getUser(user.id).then(x => {
      user.password = x.password;
      user.canViewPassword = true;
    });
  }

  addNewUser(): void {
  }

  clearUser(): void {
    this.newUser = new User('', '', '', '', '', '', '', 'STUDENT', false, new Date(), new Date());
  }

}
