import { Component } from '@angular/core';
import { LoginData } from 'src/models/LoginData';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model: LoginData = new LoginData();

  constructor() { }

  loginEvent(): void {
  }
}
