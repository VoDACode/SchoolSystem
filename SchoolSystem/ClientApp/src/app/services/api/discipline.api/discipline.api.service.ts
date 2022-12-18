import { Injectable } from '@angular/core';
import { Discipline } from 'src/models/Discipline';
import { BaseResponse } from 'src/types/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class DisciplineApiService {

  constructor() { }

  getDisciplines(): Promise<BaseResponse<Discipline[]>> {
    return fetch('api/discipline', {method: 'GET'})
    .then(response => response.json())
    .then(data => data as BaseResponse<Discipline[]>);
  }

  createDiscipline(discipline: Discipline): Promise<BaseResponse<Discipline>> {
    return fetch('api/discipline', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        Code: discipline.disciplineCode,
        Name: discipline.disciplineFullName,
      })
    })
    .then(response => response.json())
    .then(data => data as BaseResponse<Discipline>);
  }

  updateDiscipline(discipline: Discipline): Promise<BaseResponse<Discipline>> {
    return fetch(`api/discipline`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        Code: discipline.disciplineCode,
        Name: discipline.disciplineFullName,
      })
    })
    .then(response => response.json())
    .then(data => data as BaseResponse<Discipline>);
  }

  deleteDiscipline(discipline: Discipline): Promise<BaseResponse<Discipline>> {
    return fetch(`api/discipline`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        Code: discipline.disciplineCode,
        Name: discipline.disciplineFullName,
      })
    })
    .then(response => response.json())
    .then(data => data as BaseResponse<Discipline>);
  }
}
