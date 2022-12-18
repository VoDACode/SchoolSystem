import { Injectable } from '@angular/core';
import { Admin } from 'src/models/AdminModel';
import { PageData } from 'src/models/PageData';
import { Parent } from 'src/models/ParentModel';
import { Student } from 'src/models/StudentModel';
import { Teacher } from 'src/models/TeacherModel';
import { User } from 'src/models/UserModel';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class UsersApiService {

  constructor() { }

  public getUsers(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<User[]>>> {
    return fetch(`/api/users?page=${page < 1 ? 1 : page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(data => data as BaseResponse<PageData<User[]>>);
  }

  public getUser(id: number): Promise<BaseResponse<User>> {
    return fetch('/api/users/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<User>);
  }

  public deleteUser(id: number): Promise<BaseResponse<null>> {
    return fetch('/api/users/' + id, {
      method: 'DELETE'
    }).then(response => response.json())
      .then(data => data as BaseResponse<null>);
  }

  public getStudents(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<Student[]>>> {
    return fetch(`/api/users/students?page=${page < 1 ? 1 : page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(data => data as BaseResponse<PageData<Student[]>>);
  }

  public getStudent(id: number): Promise<BaseResponse<Student>> {
    return fetch('/api/users/students/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Student>);
  }

  public getTeachers(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<Teacher[]>>> {
    return fetch(`/api/users/teachers?page=${page < 1 ? 1 : page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(data => data as BaseResponse<PageData<Teacher[]>>);
  }

  public getTeacher(id: number): Promise<BaseResponse<Teacher>> {
    return fetch('/api/users/teachers/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Teacher>);
  }

  public getParents(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<Parent[]>>> {
    return fetch(`/api/users/parents?page=${page < 1 ? 1 : page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(data => data as BaseResponse<PageData<Parent[]>>);
  }

  public getParent(id: number): Promise<BaseResponse<Parent>> {
    return fetch('/api/users/parents/' + id)
      .then(response => response.json())
      .then(data => data as BaseResponse<Parent>);
  }

  public getAdmins(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<Admin[]>>> {
    return fetch(`/api/users/admins?page=${page < 1 ? 1 : page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(data => data as BaseResponse<PageData<Admin[]>>);
  }

  public getAdmin(id: number): Promise<BaseResponse<Admin>> {
    return fetch('/api/users/admins/' + id)
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
