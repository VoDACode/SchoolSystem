export class FirstUserModel {
    public firstName: string = "";
    public lastName: string = "";
    public middleName: string | undefined;
    public birthDate: Date = new Date();
    public phone: string = "";
    public login: string = "";
    public email: string = "";
    public password: string = "";
    public passwordConfirm: string = "";
}