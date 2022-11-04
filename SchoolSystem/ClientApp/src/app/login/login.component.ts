import { Component, ElementRef, ViewChild } from '@angular/core';
import { LoginData } from 'src/models/LoginData';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  @ViewChild('error') errorElement: ElementRef<HTMLSpanElement> | undefined = undefined;

  model: LoginData = new LoginData();

  constructor() { }

  onChangeInput(): void {
    //@ts-ignore
    this.errorElement.nativeElement.innerText = "";
  }

  loginEvent(): void {
    //@ts-ignore
    this.errorElement.nativeElement.innerText = "Incorrect login or password.";
  }
}
