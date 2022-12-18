import { ShortTeacherView } from "./ShortTeacher";

export class Group {
    public studentsIds: number[] = [];
    public groupStatus: string | undefined;
    public dateOfCreation: Date | undefined;
    public studentsCount: number = 0;
    constructor(
        public groupCode: string,
        public classTeacher: ShortTeacherView,
        ){}
}