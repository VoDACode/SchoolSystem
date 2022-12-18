import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/UserModel';
import { UsersApiService } from '../services/api/users.api/users.api.service';
import { StorageService } from '../services/storage/storage.service';
import { ModalService } from '../_modal';
import { AccsesLevel } from '../../types/AccsesLevelType';
import { Address } from 'src/models/AddressModel';
import { BaseResponse } from 'src/types/BaseResponse';
import { NavigatorData } from '../page-navigator/navgator-data';
import { Discipline } from 'src/models/Discipline';
import { DisciplineApiService } from '../services/api/discipline.api/discipline.api.service';

@Component({
  selector: 'app-administrate-users',
  templateUrl: './administrate.users.component.html',
  styleUrls: ['./administrate.users.component.css']
})
export class AdministrateUsersComponent implements OnInit, AfterViewInit {

  editMode = false;
  users: User[] = [];
  itemLimit = 25;
  createStep = 0;

  navigatorData: NavigatorData = new NavigatorData(0, 0, 6);

  accsesLevels: string[] = Object.keys(AccsesLevel);

  disciplines: DisciplineViewModel[] = [];

  relativesList: RelationshipsFromUserModel[] = [];

  address = new Address('', '', '', '', '', '', 1);
  dateStartWork = new Date();
  dateEndWork = new Date();

  searchInModal = '';

  searchText = '';

  userInForm: User = new User(0, '', '', '', '', '', '', new Date(), AccsesLevel.STUDENT);

  get getSearchText(): string | undefined {
    return this.searchText.length > 0 ? this.searchText : undefined;
  }

  constructor(private router: Router,
              private storage: StorageService,
              private usersApi: UsersApiService,
              private modalService: ModalService,
              private disciplineApiService: DisciplineApiService) { }

  ngAfterViewInit(): void {
  }

  ngOnInit(): void {
    if (this.storage.accsesLevel != 'ADMIN') {
      this.router.navigate(['/home']);
    } else {
      this.usersApi.getUsers(1, this.itemLimit).then(x => {
        if (!!x.data?.data){
          this.users = x.data.data;
          this.navigatorData = new NavigatorData(x.data.totalPages, x.data.page, 6);
        }
      });
    }
    this.modalService.add('student_editor');
  }

  onChangePage(page: number): void {
    this.navigatorData.currentPage = page;
    this.usersApi.getUsers(page, this.itemLimit,this.getSearchText).then(x => {
      if (!!x.data?.data){
        this.users = x.data.data;
        this.navigatorData = new NavigatorData(x.data.totalPages, x.data.page, 6);
      }
    });
  }

  viewPassword(user: User): void {
    this.usersApi.getPassword(user.id).then(x => {
      user.password = x.data || "";
      user.canViewPassword = true;
    });
  }

  addNewUser(): void {
    this.editMode = false;
    this.userInForm = new User(0, '', '', '', '', '', '', new Date(), AccsesLevel.STUDENT);
    this.createStep = 0;
    this.modalService.open('student_editor');
  }

  prePage(): void {
    this.createStep--;
  }

  nextPage(): void {
    this.createStep++;
    if (this.createStep > 0) {
      if (this.userInForm.accsesLevel == AccsesLevel.ADMIN) {
        this.modalService.close('student_editor');
        this.createUser();
        this.onCloseModal();
      }
    }
  }

  createUser(): void {
    let url = `api/users/`;
    let obj: any = {
      FirstName: this.userInForm.firstName,
      LastName: this.userInForm.lastName,
      MiddleName: this.userInForm.middleName,
      BirthDate: this.userInForm.birthDate,
      Phone: this.userInForm.phone,
      Email: this.userInForm.email
    };
    if (this.userInForm.accsesLevel == AccsesLevel.ADMIN) {
      url += '';
    } else if (this.userInForm.accsesLevel == AccsesLevel.PARENT) {
      url += 'parent';
    } else if (this.userInForm.accsesLevel == AccsesLevel.STUDENT) {
      url += 'student';
      obj.Country = this.address.country;
      obj.Region = this.address.region;
      obj.Area = this.address.area;
      obj.Settlement = this.address.settlement;
      obj.Street = this.address.street;
      obj.House = this.address.house;
      obj.Flat = this.address.flat;
      obj.DateOfEntry = this.dateStartWork;
    } else if (this.userInForm.accsesLevel == AccsesLevel.TEACHER) {
      url += 'teacher';
      obj.DateStartWork = this.dateStartWork;
    }
    fetch(url, {
      method: 'POST',
      body: JSON.stringify(obj),
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<User>;
        if (data.success && data.data) {
          this.users.push(data.data);
          this.modalService.close('student_editor');
          this.onCloseModal();
        } else {
          alert(data.message);
        }
      });
  }

  deleteUser(user: User): void {
    this.usersApi.deleteUser(user.id).then(x => {
      if (x.success) {
        this.users.splice(this.users.indexOf(user), 1);
      } else {
        alert(x.message);
      }
    });
  }

  editUser(user: User): void {
    this.editMode = true;
    this.relativesList = [];
    this.userInForm = user;
    if (user.accsesLevel == AccsesLevel.STUDENT) {
      this.usersApi.getStudent(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.address = x.data.address;
          this.dateStartWork = new Date(x.data.dateOfEntry);
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.relativesList = x.data.parents?.map(p => new RelationshipsFromUserModel(p.id,
            `${p.lastName} ${p.firstName}${(p.middleName !== undefined ? ' ' + p.middleName : '')}`
            , p.birthDate, true)) || [];
          this.loadRelativesList('PARENT');
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.TEACHER) {
      this.usersApi.getTeacher(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.dateStartWork = new Date(x.data.dateStartWork);
          this.dateEndWork = new Date(x.data.dateEndWork);
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.loadTeacherDisciplines().then(() => {
            this.disciplineApiService.getDisciplines().then(x => {
              if (x.success && x.data) {
                x.data.forEach(d => {
                  if(this.disciplines.find(p => p.disciplineCode == d.disciplineCode) == undefined)
                    this.disciplines.push(new DisciplineViewModel(d.disciplineCode, d.disciplineFullName, false));
                });
              }
              this.disciplines.sort((a, b) => a.selected == b.selected ? 0 : a.selected ? -1 : 1)
            });
          });
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.PARENT) {
      this.usersApi.getParent(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.relativesList = x.data.children?.map(p => new RelationshipsFromUserModel(p.id,
            `${p.lastName} ${p.firstName}${(p.middleName !== undefined ? ' ' + p.middleName : '')}`
            , p.birthDate, true)) || [];
          this.loadRelativesList('STUDENT');
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.ADMIN) {
      this.usersApi.getAdmin(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    }
  }

  selectDiscipline(discipline: DisciplineViewModel): void {
    discipline.selected = !discipline.selected;
  }

  onCloseModal(): void {
    this.editMode = false;
    this.createStep = 0;
    this.userInForm = new User(0, '', '', '', '', '', '', new Date(), AccsesLevel.STUDENT);
  }

  saveChanges(): void {
    console.log(this.userInForm);
    let url = `api/users/`;
    let obj: any = {
      FirstName: this.userInForm.firstName,
      LastName: this.userInForm.lastName,
      MiddleName: this.userInForm.middleName,
      BirthDate: this.userInForm.birthDate.toISOString().split('.0000Z')[0],
      Phone: this.userInForm.phone,
      Email: this.userInForm.email
    };
    if (this.userInForm.accsesLevel == AccsesLevel.ADMIN) {
      url += 'admins';
    } else if (this.userInForm.accsesLevel == AccsesLevel.PARENT) {
      url += 'parents';
    } else if (this.userInForm.accsesLevel == AccsesLevel.STUDENT) {
      url += 'students';
      obj.Country = this.address.country;
      obj.Region = this.address.region;
      obj.Area = this.address.area;
      obj.Settlement = this.address.settlement;
      obj.Street = this.address.street;
      obj.House = this.address.house;
      obj.Flat = this.address.flat;
      obj.DateOfEntry = this.dateStartWork.toISOString().split('T')[0];
    } else if (this.userInForm.accsesLevel == AccsesLevel.TEACHER) {
      url += 'teachers';
      obj.DateStartWork = this.dateStartWork.toISOString().split('T')[0]
    }
    url += `/${this.userInForm.id}`;
    fetch(url, {
      method: 'PUT',
      body: JSON.stringify(obj),
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<User>;
        if (data.success) {
          this.modalService.close('student_editor');
          this.onCloseModal();
        } else {
          alert(data.message);
        }
      });
    url = `api/users/[R]/${this.userInForm.id}/update-relatives`;

    if(this.userInForm.accsesLevel == AccsesLevel.STUDENT){
      url = url.replace('[R]', 'students');
    }else if(this.userInForm.accsesLevel == AccsesLevel.PARENT){
      url = url.replace('[R]', 'parents');
    }
    fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        RelativeIDs: this.relativesList.filter(x => x.selected).map(x => x.id)
      })
    }).then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<User>;
        if (data.success) {
          this.modalService.close('student_editor');
          this.onCloseModal();
        } else {
          alert(data.message);
        }
      });
  }

  changePassword(): void {
    fetch(`api/users/${this.userInForm.id}/change-password`, {
      method: 'PUT'
    }).then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<User>;
        if (data.success) {
          alert('Пароль було змінено');
        } else {
          alert(data.message);
        }
      });
  }

  parseDate(event: any): Date {
    if (event) {
      return new Date(event.target.value);
    }
    return new Date();
  }

  loadRelativesList(type: 'PARENT' | 'STUDENT', q: string = ""): void {
    let url = `api/search/`;
    if (type == 'PARENT') {
      url += 'parents';
    } else if (type == 'STUDENT') {
      url += 'students';
    }
    url += `?top=${Math.max(10 - this.relativesList.length, 0)}`;
    if (q != "" && q != undefined) {
      url += `&q=${q}`;
    }
    fetch(url)
      .then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<User[]>;
        if (data.success && data.data) {
          this.relativesList = data.data.map(p => new RelationshipsFromUserModel(p.id,
            `${p.lastName} ${p.firstName}${(p.middleName !== undefined ? ' ' + p.middleName : '')}`
            , p.birthDate, this.relativesList.findIndex(x => x.id == p.id) != -1));
        } else {
          alert(data.message);
        }
      });
  }

  loadTeacherDisciplines(): Promise<void> {
    this.disciplines = [];
    return fetch(`api/users/teacher/${this.userInForm.id}/disciplines`)
      .then(response => response.json())
      .then(json => {
        let data = json as BaseResponse<Discipline[]>;
        if (data.success && data.data) {
          this.disciplines = data.data.map(p => new DisciplineViewModel(p.disciplineCode, p.disciplineFullName, true));
        } else {
          alert(data.message);
        }
      });
  }

  searchChange(): void {
    this.relativesList = [];
    this.loadRelativesList(this.userInForm.accsesLevel == AccsesLevel.PARENT ? 'STUDENT' : 'PARENT', this.searchInModal);
  }

  searchUsers(): void {
    this.usersApi.getUsers(0, this.itemLimit,this.getSearchText).then(x => {
      if (!!x.data?.data){
        this.users = x.data.data;
        this.navigatorData = new NavigatorData(x.data.totalPages, x.data.page, 6);
      }
    });
  }

  selectRelative(id: number): void {
    this.relativesList = this.relativesList.map(p => {
      if (p.id == id) {
        p.selected = !p.selected;
      }
      return p;
    });
  }
}
class RelationshipsFromUserModel {
  constructor(
    public id: number,
    public fullName: string,
    public birthDate: Date,
    public selected: boolean,
  ) { }
}
class DisciplineViewModel implements Discipline {
  constructor(
    public disciplineCode: string,
    public disciplineFullName: string,
    public selected: boolean,
) { }
}
