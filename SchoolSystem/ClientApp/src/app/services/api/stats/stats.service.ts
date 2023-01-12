import { Injectable } from '@angular/core';
import { ShortStudent } from 'src/models/ShortStudent';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class StatsService {

  constructor() { }

  getTeachers(): Promise<BaseResponse<{teachers: number, students: number, teachersPerStudent: number}>> {
    return fetch('/api/statistics/teachers')
    .then(res => res.json())
    .then(res => res as BaseResponse<{teachers: number, students: number, teachersPerStudent: number}>);
  }

  getStudents(groupNum: number): Promise<BaseResponse<{group: string, students: number}[]>> {
    return fetch('/api/statistics/students?group=' + groupNum)
    .then(res => res.json())
    .then(res => res as BaseResponse<{group: string, students: number}[]>);
  }

  getParents(groupNum: number): Promise<BaseResponse<{group: string, parents: number}[]>> {
    return fetch('/api/statistics/parents?group=' + groupNum)
    .then(res => res.json())
    .then(res => res as BaseResponse<{group: string, parents: number}[]>);
  }

  getParentsInGroup(group: string): Promise<BaseResponse<ShortStudent[]>> {
    return fetch('/api/statistics/parentsInGroup?group=' + group)
    .then(res => res.json())
    .then(res => res as BaseResponse<ShortStudent[]>);
  }
}
