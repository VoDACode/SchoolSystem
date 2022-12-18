import { AccsesLevel } from "src/types/AccsesLevelType";
import { Student } from "./StudentModel";
import { User } from "./UserModel";


export class Parent implements User {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public middleName: string,
        public phone: string,
        public login: string,
        public email: string,
        public birthDate: Date,
        public accsesLevel: AccsesLevel, 
        public children: Student[] | null
    ){}
    canViewPassword: boolean = false;
    password: string = "";
    get isAdmin(): boolean {
        throw new Error("Method not implemented.");
    }
    get isStudent(): boolean {
        throw new Error("Method not implemented.");
    }
    get isTeacher(): boolean {
        throw new Error("Method not implemented.");
    }
    get isParent(): boolean {
        throw new Error("Method not implemented.");
    }
    get isUnknown(): boolean {
        throw new Error("Method not implemented.");
    }

}
