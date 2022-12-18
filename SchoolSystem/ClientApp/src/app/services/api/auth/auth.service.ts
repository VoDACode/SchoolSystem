import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { UserClaim } from 'src/interfaces/ApiResponses';
import { LoginData } from 'src/models/LoginData';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  public logIn(data: LoginData): Promise<BaseResponse<null>> {
    return fetch('/api/account/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    }).then(response => {
      return response.json() as Promise<BaseResponse<null>>;
    });
  }
  public logOut() {
    return this.http.get('api/account/logout');
  }
  public user() {
    return this.http.get<BaseResponse<UserClaim[]>>('api/account/user');
  }
  public isLogedIn(): Observable<boolean> {
    return this.user().pipe(
      map((res) => {
        const hasClaims = res.data!.length > 0;
        return !hasClaims ? false : true;
      }),
      catchError((error) => {
        console.error(error);
        return of(false);
      }));
  }
}
