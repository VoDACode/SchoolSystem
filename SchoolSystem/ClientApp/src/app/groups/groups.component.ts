import { Component, OnInit } from '@angular/core';
import { iif } from 'rxjs';
import { Group } from 'src/models/Group';
import { ShortStudent } from 'src/models/ShortStudent';
import { ShortTeacherView } from 'src/models/ShortTeacher';
import { Student } from 'src/models/StudentModel';
import { Teacher } from 'src/models/TeacherModel';
import { AccsesLevel } from 'src/types/AccsesLevelType';
import { NavigatorData } from '../page-navigator/navgator-data';
import { GroupApiService } from '../services/api/group.api/group.api.service';
import { ReportsService } from '../services/api/reports/reports.service';
import { UsersApiService } from '../services/api/users.api/users.api.service';
import { ModalService } from '../_modal';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  modalNavigator: NavigatorData = new NavigatorData(0, 0, 6);
  studentsNavigator: NavigatorData = new NavigatorData(0, 0, 6);
  groupNavigator: NavigatorData = new NavigatorData(0, 0, 6);

  groups: Group[] = [];

  selectGroup: Group = new Group("NaN", new ShortTeacherView(-1, "", "", ""));

  teachers: TeacherView[] = [];
  students: StudentView[] = [];
  selectedTeacher: TeacherView | null = null;
  selectedStudents: StudentView[] = [];

  editMode: boolean = false;

  searchText: string = "";

  searchInModal: string = "";
  searchInStudents: string = "";

  isValidCode: boolean = true;
  oldTeacherId: number = -1;
  oldStatus: string | undefined;
  get isCorrectModalData(): boolean {
    if (!this.editMode) {
      return this.selectGroup.groupCode != "" && this.selectedTeacher != null && this.isValidCode;
    } else {
      return ((this.selectedTeacher != null && this.oldTeacherId != this.selectedTeacher.id) || this.oldStatus != this.selectGroup.groupStatus) && this.isValidCode;
    }
  }

  constructor(private groupApi: GroupApiService,
    private modal: ModalService,
    private usersApi: UsersApiService,
    private reports: ReportsService) { }

  ngOnInit(): void {
    this.groupApi.getGroups()
      .then(response => {
        if (response.success && response.data) {
          this.groups = response.data.data;
          console.log(this.groups);
        }
      });
  }

  onInputGroupCode(event: any) {
    if (!(/[0-9]+(\-[A-Za-zА-Яа-я])?$/.test(event.target.value))) {
      this.isValidCode = false;
    } else {
      this.groupApi.exists(event.target.value).then(response => {
        if (response.success) {
          this.isValidCode = !response.data;
        }
      });
    }
  }

  pageChange(page: number): void {
    this.usersApi.getTeachers(page).then(response => {
      if (response.success && response.data) {
        this.teachers = response.data.data.map(teacher => new TeacherView(teacher, check(teacher.id)));
        this.modalNavigator = new NavigatorData(response.data.totalPages, page, 6);
      }
    });
    const check = (id: number) => {
      if (!this.editMode) {
        return this.selectedTeacher?.id == id;
      } else {
        return this.selectGroup.classTeacher.id == id;
      }
    }
  }

  pageStudentsChange(page: number): void {
    this.groupApi.getStudentsInGroup(this.selectGroup.groupCode, page, 10, this.searchInStudents).then(response => {
      if (response.success && response.data) {
        this.students = response.data.data.map(s => new StudentView(s, s.inGroup));
        this.students.forEach(student => {
          if (student.selected && !this.selectedStudents.some(s => s.id == student.id)) {
            this.selectedStudents.push(student);
          } else if (!student.selected && this.selectedStudents.some(s => s.id == student.id)) {
            this.selectedStudents.splice(this.selectedStudents.findIndex(s => s.id == student.id), 1);
          }

        });
        this.studentsNavigator = new NavigatorData(response.data.totalPages, page, 6);
      }
    });
    const check = (student: ShortStudent) => {
      return student.groups.findIndex(p => p == this.selectGroup.groupCode) > -1 ||
        this.selectedStudents.findIndex(s => s.id == student.id) > -1;
    }
  }

  selectTeacher(teacher: TeacherView): void {
    if (this.teachers.find(t => t.selected)) {
      this.teachers.find(t => t.selected)!.selected = false;
    }
    teacher.selected = !teacher.selected;
    if (teacher.selected) {
      this.selectedTeacher = teacher;
    } else {
      this.selectedTeacher = null;
    }
  }

  searchInModalChange(): void {
    this.usersApi.getTeachers(1, 10, this.searchInModal).then(response => {
      if (response.success && response.data) {
        this.teachers = response.data.data.map(teacher => new TeacherView(teacher, check(teacher.id)));
        this.modalNavigator = new NavigatorData(response.data.totalPages, 1, 6);
      }
    }
    );
    const check = (id: number) => {
      if (!this.editMode) {
        return this.selectedTeacher?.id == id;
      } else {
        return this.selectGroup.classTeacher.id == id;
      }
    }
  }

  searchInStudentsChange(): void {
    this.groupApi.getStudentsInGroup(this.selectGroup.groupCode, 1, 10, this.searchInStudents).then(response => {
      if (response.success && response.data) {
        this.students = response.data.data.map(s => new StudentView(s, s.inGroup));
        this.students.forEach(student => {
          if (student.selected && !this.selectedStudents.some(s => s.id == student.id)) {
            this.selectedStudents.push(student);
          } else if (!student.selected && this.selectedStudents.some(s => s.id == student.id)) {
            this.selectedStudents.splice(this.selectedStudents.findIndex(s => s.id == student.id), 1);
          }
        });
        this.studentsNavigator = new NavigatorData(response.data.totalPages, 1, 6);
      }
    });
  }

  selectStudent(student: StudentView): void {
    student.selected = !student.selected;
    if (student.selected) {
      this.selectedStudents.push(student);
    } else {
      const index = this.selectedStudents.findIndex(s => s.id == student.id);
      if (index > -1) {
        this.selectedStudents.splice(index, 1);
      }
    }
    console.log(this.selectedStudents);
  }

  deleteGroup(group: Group) {
    this.groupApi.deleteGroup(group.groupCode)
      .then(response => {
        if (response.success) {
          const index = this.groups.indexOf(group);
          if (index > -1) {
            this.groups.splice(index, 1);
          }
        } else {
          console.error("Error: " + response.message);
        }
      });
  }

  search(): void {
    this.groupApi.getGroups(1, 10, this.searchText).then(response => {
      if (response.success && response.data) {
        this.groups = response.data.data;
        this.groupNavigator = new NavigatorData(response.data.totalPages, 1, 6);
      }
    });
  }

  addNew() {
    this.selectedTeacher = null;
    this.selectGroup = new Group("", new ShortTeacherView(-1, "", "", ""));
    this.editMode = false;
    this.loadTeachers(-1);
    this.modal.open("group-modal");
  }

  save() {
    if (this.editMode) {
      this.selectGroup.classTeacher = new ShortTeacherView(this.selectedTeacher!.id, this.selectedTeacher!.firstName, this.selectedTeacher!.lastName, this.selectedTeacher!.middleName);
      this.groupApi.updateGroup(this.selectGroup)
        .then(response => {
          if (!(response.success && response.data)) {
            console.error("Error: " + response.message);
          }
        });
    } else {
      this.selectGroup.classTeacher = new ShortTeacherView(this.selectedTeacher!.id, this.selectedTeacher!.firstName, this.selectedTeacher!.lastName, this.selectedTeacher!.middleName);
      this.groupApi.createGroup(this.selectGroup)
        .then(response => {
          if (response.success) {
            this.groups.push(response.data as Group);
          } else {
            console.error("Error: " + response.message);
          }
        });
    }
    this.closeModal();
  }

  saveStudents(): void {
    this.groupApi.updataStudentsToGroup(this.selectGroup.groupCode, this.selectedStudents.filter(p => p.selected).map(s => s.id))
      .then(response => {
        if (!response.success) {
          console.error("Error: " + response.message);
        } else {
          this.groups.find(g => g.groupCode == response.data?.groupCode)!.studentsIds = response.data?.studentsIds || [];
        }
      });
    this.closeStudentsModal();
  }

  closeModal(): void {
    this.modal.close("group-modal");
    this.selectGroup = new Group("", new ShortTeacherView(-1, "", "", ""));
    this.selectedTeacher = null;
    this.isValidCode = true;
    this.teachers.length = 0;
  }

  closeStudentsModal(): void {
    this.modal.close("group-students-modal");
    this.selectGroup = new Group("", new ShortTeacherView(-1, "", "", ""));
    this.selectedStudents.length = 0;
    this.students.length = 0;
  }

  configureStudents(group: Group) {
    this.selectGroup = group;
    this.loadStudents();
    this.modal.open("group-students-modal");
  }

  edit(group: Group) {
    this.selectGroup = group;
    this.oldTeacherId = group.classTeacher.id;
    this.oldStatus = group.groupStatus;
    this.selectedTeacher = new TeacherView(
      new Teacher(group.classTeacher.id, group.classTeacher.firstName, group.classTeacher.lastName, group.classTeacher.middleName, '', '', '', new Date(), AccsesLevel.TEACHER, new Date(), new Date()),
      true
    );
    this.editMode = true;
    this.loadTeachers(this.selectGroup.classTeacher.id);
    this.modal.open("group-modal");
  }

  delete(group: Group) {
    this.groupApi.deleteGroup(group.groupCode)
      .then(response => {
        if (response.success) {
          const index = this.groups.indexOf(group);
          if (index > -1) {
            this.groups.splice(index, 1);
          }
        } else {
          console.error("Error: " + response.message);
        }
      });
  }

  loadTeachers(teatherId: number): void {
    this.usersApi.getTeachers().then(response => {
      if (response.success && response.data) {
        this.teachers = this.selectedTeacher ? [this.selectedTeacher] : [];
        const index = response.data.data.findIndex(t => t.id == this.selectedTeacher?.id);
        if(index > -1) {
          response.data.data.splice(index, 1);
        }
        this.teachers.push(...response.data.data.map(teacher => new TeacherView(teacher, teacher.id == teatherId)));
        this.modalNavigator = new NavigatorData(response.data.totalPages, response.data.page, 6);
      }
    });
  }

  loadStudents(): void {
    this.groupApi.getStudentsInGroup(this.selectGroup.groupCode).then(response => {
      if (response.success && response.data) {
        this.students = response.data.data.map(student => new StudentView(student, student.inGroup));
        this.students.forEach(student => {
          if (student.selected && !this.selectedStudents.some(s => s.id == student.id)) {
            this.selectedStudents.push(student);
          }
        });
        this.studentsNavigator = new NavigatorData(response.data.totalPages, response.data.page, 6);
      }
    });
  }

  downloadStudents(group: string): void {
    this.reports.downloadStudentsList(group);
  }
}
class TeacherView implements Teacher {
  canViewPassword: boolean = false;
  password: string = "";
  public id: number;
  public firstName: string;
  public lastName: string;
  public middleName: string;
  public phone: string;
  public login: string;
  public email: string;
  public birthDate: Date;
  public accsesLevel: AccsesLevel;
  public dateStartWork: Date;
  public dateEndWork: Date;
  constructor(teather: Teacher, public selected: boolean) {
    this.id = teather.id;
    this.firstName = teather.firstName;
    this.lastName = teather.lastName;
    this.middleName = teather.middleName;
    this.phone = teather.phone;
    this.login = teather.login;
    this.email = teather.email;
    this.birthDate = teather.birthDate;
    this.accsesLevel = teather.accsesLevel;
    this.dateStartWork = teather.dateStartWork;
    this.dateEndWork = teather.dateEndWork;
  }
  get isAdmin(): boolean {
    throw new Error('Method not implemented.');
  }
  get isStudent(): boolean {
    throw new Error('Method not implemented.');
  }
  get isTeacher(): boolean {
    throw new Error('Method not implemented.');
  }
  get isParent(): boolean {
    throw new Error('Method not implemented.');
  }
  get isUnknown(): boolean {
    throw new Error('Method not implemented.');
  }

}

class StudentView implements ShortStudent {
  public id: number;
  public firstName: string;
  public lastName: string;
  public middleName: string;
  public groups: string[] = [];
  constructor(student: ShortStudent, public selected: boolean) {
    this.id = student.id;
    this.firstName = student.firstName;
    this.lastName = student.lastName;
    this.middleName = student.middleName;
  }
}