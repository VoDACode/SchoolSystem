import { ShortStudent } from "./ShortStudent";

export class StudentInGroupView implements ShortStudent{
    public groups: string[] = [];
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public middleName: string,
        public inGroup: boolean,
    ){}
}