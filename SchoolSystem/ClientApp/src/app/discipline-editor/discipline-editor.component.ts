import { Component, OnInit } from '@angular/core';
import { Discipline } from 'src/models/Discipline';
import { DisciplineApiService } from '../services/api/discipline.api/discipline.api.service';
import { ModalService } from '../_modal';

@Component({
  selector: 'app-discipline-editor',
  templateUrl: './discipline-editor.component.html',
  styleUrls: ['./discipline-editor.component.css']
})
export class DisciplineEditorComponent implements OnInit {

  disciplines: Discipline[] = [];
  searchText: string = "";

  editMode = false;

  discipline: Discipline = new Discipline("", "");

  constructor(private _modal: ModalService, private _disciplineApi: DisciplineApiService) { }

  ngOnInit(): void {
    this._disciplineApi.getDisciplines().then(data => {
      if (data.success) {
        this.disciplines = data.data || [];
      } else {
        alert(data.message);
      }
    });
  }

  edit(discipline: Discipline) {
    this.editMode = true;
    this.discipline = discipline;
    this._modal.open('add-or-edit-discipline');
    console.log(discipline);
  }

  delete(discipline: Discipline) {
    this._disciplineApi.deleteDiscipline(discipline).then(data => {
      if (data.success) {
        let index = this.disciplines.indexOf(discipline);
        if (index > -1) {
          this.disciplines.splice(index, 1);
        }
      } else {
        alert(data.message);
      }
    });
  }

  search(): void {
  }

  addNew(): void {
    this.closeModal();
    this._modal.open('add-or-edit-discipline');
  }

  closeModal(): void {
    this._modal.close('add-or-edit-discipline');
    this.discipline = new Discipline("", "");
    this.editMode = false;
  }

  save(): void {
    if (!this.editMode) {
      this._disciplineApi.createDiscipline(this.discipline).then(data => {
        if (data.success && data.data) {
          this.disciplines.push(data.data);
        } else {
          alert(data.message);
        }
      });
    } else {
      let item = this.disciplines.find(p => p.disciplineCode == this.discipline.disciplineCode);
      if (item) {
        this._disciplineApi.updateDiscipline(item).then(data => {
          if (data.success) {
            item = this.disciplines.find(p => p.disciplineCode == data.data?.disciplineCode);
            if (item) {
              item.disciplineFullName = data.data?.disciplineFullName || "";
            }
          } else {
            alert(data.message);
          }
        });
      }
    }
    this.closeModal();
  }
}
