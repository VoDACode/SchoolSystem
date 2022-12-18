import { StorageService } from './../services/storage/storage.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { LoginData } from 'src/models/LoginData';
import { AccsesLevel } from 'src/types/AccsesLevelType';
import { ClaimTypes } from 'src/types/ClaimTypes';
import { AuthService } from '../services/api/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('error') errorElement: ElementRef<HTMLSpanElement> | undefined = undefined;

  model: LoginData = new LoginData();

  constructor(private router: Router, private storage: StorageService, private auth: AuthService) { }
  ngOnInit(): void {
    this.auth.user().subscribe(res => {
      if (res.success) {
        this.storage.accsesLevel = res.data!.find(p => p.type == ClaimTypes.Role)?.value as AccsesLevel;
        this.router.navigate(['/home']);
      }
    });
  }

  onChangeInput(): void {
    //@ts-ignore
    this.errorElement.nativeElement.innerText = "";
  }

  loginEvent(): void {
    this.auth.logIn(this.model).then(response => {
      console.log(response);
        if (response.success) {
          setTimeout(() => {
            this.auth.user().subscribe(res => {
              if (res.success) {
                this.storage.accsesLevel = res.data!.find(p => p.type == ClaimTypes.Role)?.value as AccsesLevel;
              }
            });
          }, 200);
          this.router.navigate(['home']);
        } else {
          //@ts-ignore
          this.errorElement.nativeElement.innerText = "Login failed";
        }
    });
  }
}
