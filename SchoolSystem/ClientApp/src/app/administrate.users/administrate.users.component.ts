import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/UserModel';
import { ApiService } from '../services/api/api.service';
import { StorageService } from '../services/storage/storage.service';
import { ModalService } from '../_modal';
import { AccsesLevel } from '../../types/AccsesLevelType';
import { Address } from 'src/models/AddressModel';
import { BaseResponse } from 'src/types/BaseResponse';
import { NavigatorData } from '../page-navigator/navgator-data';

@Component({
  selector: 'app-administrate-users',
  templateUrl: './administrate.users.component.html',
  styleUrls: ['./administrate.users.component.css']
})
export class AdministrateUsersComponent implements OnInit {

  editMode = false;
  users: User[] = [];

  createStep = 0;

  navigatorData: NavigatorData = new NavigatorData(100, 50, 6);

  accsesLevels: string[] = Object.keys(AccsesLevel);

  relativesList: RelationshipsFromUserModel[] = [];

  address = new Address('', '', '', '', '', '', 1);
  dateStartWork = new Date();
  dateEndWork = new Date();

  searchInModal = '';

  searchText = '';

  userInForm: User = new User(0, '', '', '', '', '', '', new Date(), AccsesLevel.STUDENT);

  constructor(private router: Router, private storage: StorageService, private api: ApiService, private modalService: ModalService) { }

  ngOnInit(): void {
    if (this.storage.accsesLevel != 'ADMIN') {
      this.router.navigate(['/home']);
    } else {
      this.api.getUsers().then(x => {
        if (!!x.data)
          this.users = x.data;
      });
    }
    this.modalService.add('student_editor');
  }

  viewPassword(user: User): void {
    this.api.getPassword(user.id).then(x => {
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
      FirstName: this.userInForm.firstname,
      LastName: this.userInForm.lastname,
      MiddleName: this.userInForm.middlename,
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
    fetch(`api/users/${user.id}`, {
      method: 'DELETE'
    }).then(responce => responce.json())
      .then(data => {
        let result = data as BaseResponse<null>;
        if (result.success) {
          this.users.splice(this.users.indexOf(user), 1);
        } else {
          alert(result.message);
        }
      })
  }

  editUser(user: User): void {
    this.editMode = true;
    this.relativesList = [];
    this.userInForm = user;
    if (user.accsesLevel == AccsesLevel.STUDENT) {
      this.api.getStudent(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.address = x.data.address;
          this.dateStartWork = new Date(x.data.dateOfEntry);
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.relativesList = x.data.parents?.map(p => new RelationshipsFromUserModel(p.id,
            `${p.lastname} ${p.firstname}${(p.middlename !== undefined ? ' ' + p.middlename : '')}`
            , p.birthDate, true)) || [];
          this.loadRelativesList('PARENT');
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.TEACHER) {
      this.api.getTeacher(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.dateStartWork = new Date(x.data.dateStartWork);
          this.dateEndWork = new Date(x.data.dateEndWork);
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.PARENT) {
      this.api.getParent(user.id).then(x => {
        if (x.success && x.data) {
          this.userInForm = x.data;
          this.userInForm.birthDate = new Date(x.data.birthDate);
          this.relativesList = x.data.children?.map(p => new RelationshipsFromUserModel(p.id,
            `${p.lastname} ${p.firstname}${(p.middlename !== undefined ? ' ' + p.middlename : '')}`
            , p.birthDate, true)) || [];
          this.loadRelativesList('STUDENT');
          this.modalService.open('student_editor');
        } else {
          alert(x.message);
        }
      });
    } else if (user.accsesLevel == AccsesLevel.ADMIN) {
      this.api.getAdmin(user.id).then(x => {
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

  onCloseModal(): void {
    this.editMode = false;
    this.createStep = 0;
    this.userInForm = new User(0, '', '', '', '', '', '', new Date(), AccsesLevel.STUDENT);
  }

  saveChanges(): void {
    console.log(this.userInForm);
    let url = `api/users/`;
    let obj: any = {
      FirstName: this.userInForm.firstname,
      LastName: this.userInForm.lastname,
      MiddleName: this.userInForm.middlename,
      BirthDate: this.userInForm.birthDate,
      Phone: this.userInForm.phone,
      Email: this.userInForm.email
    };
    if (this.userInForm.accsesLevel == AccsesLevel.ADMIN) {
      url += 'admin';
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
      url = url.replace('[R]', 'student');
    }else if(this.userInForm.accsesLevel == AccsesLevel.PARENT){
      url = url.replace('[R]', 'parent');
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
            `${p.lastname} ${p.firstname}${(p.middlename !== undefined ? ' ' + p.middlename : '')}`
            , p.birthDate, this.relativesList.findIndex(x => x.id == p.id) != -1));
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
