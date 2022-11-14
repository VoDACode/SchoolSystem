import { AccsesLevel } from "src/types/AccsesLevelType";

export class User{
    canViewPassword: boolean = false;
    password: string = '';
    constructor(
        public id: string,
        public name: string,
        public surname: string,
        public middlename: string,
        public email: string,
        public phone: string,
        public login: string,
        public accsesLevel: AccsesLevel,
        public disabled: boolean,
        public created: Date,
        public updated: Date
    ){}
}