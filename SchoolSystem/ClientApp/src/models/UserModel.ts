import { AccsesLevel } from "src/types/AccsesLevelType";

export class User {
  canViewPassword: boolean = false;
  password: string = '';
  constructor(
    public id: number,
    public firstname: string,
    public lastname: string,
    public middlename: string,
    public email: string,
    public phone: string,
    public login: string,
    public birthDate: Date = new Date(),
    public accsesLevel: AccsesLevel,
  ) { }

  get isAdmin(): boolean {
    return this.accsesLevel == AccsesLevel.ADMIN;
  }
  get isStudent(): boolean {
    return this.accsesLevel == AccsesLevel.STUDENT;
  }
  get isTeacher(): boolean {
    return this.accsesLevel == AccsesLevel.TEACHER;
  }
  get isParent(): boolean {
    return this.accsesLevel == AccsesLevel.PARENT;
  }
  get isUnknown(): boolean {
    return this.accsesLevel == AccsesLevel.UNKNOWN;
  }
}
