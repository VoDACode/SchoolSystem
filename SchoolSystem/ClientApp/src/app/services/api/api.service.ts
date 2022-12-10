import { Injectable } from '@angular/core';
import { Admin } from 'src/models/AdminModel';
import { Parent } from 'src/models/ParentModel';
import { Student } from 'src/models/StudentModel';
import { Teacher } from 'src/models/TeacherModel';
import { User } from 'src/models/UserModel';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }

  public getUsers(): Promise<BaseResponse<User[]>> {
    return fetch('/api/users')
      .then(response => response.json())
      .then(data => data as BaseResponse<User[]>);
  }

  public getUser(id: number): Promise<BaseResponse<User>> {
    return fetch('/api/users/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<User>);
  }

  public getStudent(id: number): Promise<BaseResponse<Student>> {
    return fetch('/api/users/student/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Student>);
  }

  public getTeacher(id: number): Promise<BaseResponse<Teacher>> {
    return fetch('/api/users/teacher/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Teacher>);
  }

  public getParent(id: number): Promise<BaseResponse<Parent>> {
    return fetch('/api/users/parent/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Parent>);
  }

  public getAdmin(id: number): Promise<BaseResponse<Admin>> {
    return fetch('/api/users/admin/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Admin>);
  }

  public getPassword(id: number): Promise<BaseResponse<string>>{
    return fetch('api/users/getPassword/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<string>)
  }

  public isFirstStart(): Promise<boolean> {
    return fetch('/api/sys/firstStart')
      .then(response => response.json())
      .then(data => data as boolean);
  }
}
