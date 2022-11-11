export class Lesson{
    id: number;
    name: string;
    teacher: string;
    room: string;
    day: Date;
    time: number;
    duration: number;
    lesson: number;
    group: number;
    constructor(id: number, name: string, teacher: string, room: string, day: Date, lesson: number, time: number, duration: number, group: number){
        this.id = id;
        this.name = name;
        this.teacher = teacher;
        this.room = room;
        this.day = day;
        this.group = group;
        this.lesson = lesson;
        this.time = time;
        this.duration = duration;
    }

    get getFromToTime(): string {
        let date = new Date(this.time * 1000);
        let from = `${this.addNull(date.getHours())}:${this.addNull(date.getMinutes())}`;
        date.setMinutes(date.getMinutes() + this.duration);
        let to = `${this.addNull(date.getHours())}:${this.addNull(date.getMinutes())}`;
        return `${from} - ${to}`;
    }

    get calcTop(): number{
        return (this.lesson - 1) * 70;
    }

    get calcLeft(): number{
        return (this.day.getDay() - 1) * 112.5 + 29.6;
    }

    addNull(num: number): string {
        return num < 10 ? `0${num}` : `${num}`;
    }
}