import { AuthService } from './../services/auth/auth.service';
import { StorageService } from './../services/storage/storage.service';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { LoginData } from 'src/models/LoginData';
import { UserClaim } from 'src/interfaces/ApiResponses';
import { map } from 'rxjs';
import { AccsesLevel } from 'src/types/AccsesLevelType';
import { ClaimTypes } from 'src/types/ClaimTypes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  @ViewChild('error') errorElement: ElementRef<HTMLSpanElement> | undefined = undefined;

  model: LoginData = new LoginData();

  constructor(private router: Router, private storage: StorageService, private auth: AuthService) { }

  onChangeInput(): void {
    //@ts-ignore
    this.errorElement.nativeElement.innerText = "";
  }

  loginEvent(): void {
    fetch('/api/account/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(this.model)
    }).then(response => {
      if (response.status === 200) {
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
    }).catch(error => {
      //@ts-ignore
      this.errorElement.nativeElement.innerText = "Login failed";
      if (environment.debug) {
        console.error(`Login failed: ${error}`);
      }
    });
  }
}
