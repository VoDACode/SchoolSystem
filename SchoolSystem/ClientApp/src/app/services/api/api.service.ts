import { Injectable } from '@angular/core';
import { User } from 'src/models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }

  public getUsers(): Promise<User[]> {
    return fetch('/api/users')
      .then(response => response.json())
      .then(data => data as User[]);
  }

  public getUser(id: number): Promise<User> {
    return fetch('/api/users/' + id)
      .then(response => response.json())
      .then(data => data as User);
  }

  public isFirstStart(): Promise<boolean> {
    return fetch('/api/sys/firstStart')
      .then(response => response.json())
      .then(data => data as boolean);
  }
}
