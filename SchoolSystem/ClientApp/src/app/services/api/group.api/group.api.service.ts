import { Injectable } from '@angular/core';
import { Group } from 'src/models/Group';
import { PageData } from 'src/models/PageData';
import { ShortStudent } from 'src/models/ShortStudent';
import { StudentInGroupView } from 'src/models/StudentInGroupView';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class GroupApiService {

  constructor() { }

  public getGroups(page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<Group[]>>> {
    return fetch(`/api/groups?page=${page}&limit=${limit}${q ? `&q=${q}` : ''}`)
      .then(response => response.json())
      .then(json => json as BaseResponse<PageData<Group[]>>);
  }

  public getGroup(code: string): Promise<BaseResponse<Group>> {
    return fetch(`/api/groups/${code}`)
      .then(response => response.json())
      .then(json => json as BaseResponse<Group>);
  }

  public createGroup(group: Group): Promise<BaseResponse<Group>> {
    return fetch('/api/groups', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        GroupStatus: group.groupStatus,
        ClassTeacherId: group.classTeacher.id,
        GroupCode: group.groupCode
      })
    })
      .then(response => response.json())
      .then(json => json as BaseResponse<Group>);
  }

  public updateGroup(group: Group): Promise<BaseResponse<Group>> {
    return fetch(`/api/groups/${group.groupCode}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        GroupStatus: group.groupStatus,
        ClassTeacherId: group.classTeacher.id,
        GroupCode: group.groupCode
      })
    })
      .then(response => response.json())
      .then(json => json as BaseResponse<Group>);
  }

  public deleteGroup(code: string): Promise<BaseResponse<Group>> {
    return fetch(`/api/groups/${code}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(response => response.json())
      .then(json => json as BaseResponse<Group>);
  }

  public updataStudentsToGroup(code: string, studentIds: number[]): Promise<BaseResponse<Group>> {
    return fetch(`/api/groups/${code}/students`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        StudentIds: studentIds
      })
    })
      .then(response => response.json())
      .then(json => json as BaseResponse<Group>);
  }

  public getStudentsInGroup(code: string, page: number = 1, limit: number = 10, q: string | undefined = undefined): Promise<BaseResponse<PageData<StudentInGroupView[]>>> {
    return fetch(`/api/groups/${code}/students?page=${page}&limit=${limit}${q ? `&q=${q}` : ''}&display=all`)
      .then(response => response.json())
      .then(json => json as BaseResponse<PageData<StudentInGroupView[]>>)
      .then(response => {
        response.data?.data.sort(p => p.inGroup ? -1 : 1);
        return response;
      });
  }

  public exists(code: string): Promise<BaseResponse<boolean>> {
    return fetch(`/api/groups/${code}/exists`)
      .then(response => response.json())
      .then(json => json as BaseResponse<boolean>);
  }
}
