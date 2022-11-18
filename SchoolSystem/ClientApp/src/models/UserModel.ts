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
    public accsesLevel: AccsesLevel,
  ) { }
}
