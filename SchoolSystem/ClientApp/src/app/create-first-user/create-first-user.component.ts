import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FirstUserModel } from 'src/models/FirstUserModel';

@Component({
  selector: 'app-create-first-user',
  templateUrl: './create-first-user.component.html',
  styleUrls: ['./create-first-user.component.css']
})
export class CreateFirstUserComponent implements AfterViewInit {

  // RegExp for matching phone number
  phoneRegExp: RegExp = new RegExp("^\\+[0-9]{12}$");

  // RegExp for matching email
  emailRegExp: RegExp = new RegExp("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$");

  @ViewChild('firstNameError') firstNameError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('lastNameError') lastNameError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('middleNameError') middleNameError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('phoneError') phoneError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('emailError') emailError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('loginError') loginError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('passwordError') passwordError: ElementRef<HTMLSpanElement> | undefined = undefined;
  @ViewChild('inputBirthday') inputBirthday: ElementRef<HTMLInputElement> | undefined = undefined;

  model: FirstUserModel = new FirstUserModel();

  constructor() { }

  ngAfterViewInit(): void {
    var today = new Date();

    var month: any = today.getMonth() + 1;
    var day: any = today.getDate();
    var year = today.getFullYear();

    var minDate = (year - 200) + '-' + month + '-' + day;
    this.inputBirthday?.nativeElement.setAttribute('min', minDate);
    today.setMonth(today.getMonth() + 1);
    this.inputBirthday?.nativeElement.setAttribute('max', `${today.getFullYear()}-${today.getMonth()}-${today.getDate()}`);
  }

  submit(): void {
    let valid = true;

    this.firstNameError!.nativeElement.innerHTML = '';
    this.lastNameError!.nativeElement.innerHTML = '';
    this.middleNameError!.nativeElement.innerHTML = '';
    this.phoneError!.nativeElement.innerHTML = '';
    this.emailError!.nativeElement.innerHTML = '';
    this.loginError!.nativeElement.innerHTML = '';
    this.passwordError!.nativeElement.innerHTML = '';

    if (this.model.firstName == undefined || this.model.firstName.length < 2) {
      this.firstNameError!.nativeElement.innerHTML = "Ім'я не може бути коротшим за 2 символи";
      valid = false;
    }
    if (this.model.lastName == undefined || this.model.lastName.length < 2) {
      this.lastNameError!.nativeElement.innerHTML = "Прізвище не може бути коротшим за 2 символ";
      valid = false;
    }
    if (this.model.middleName !== undefined && (this.model.middleName?.length != 0 && (this.model.middleName?.length || 0) < 2)) {
      this.middleNameError!.nativeElement.innerHTML = "По батькові не може бути коротшим за 2 символи";
      valid = false;
    }
    if (this.model.phone == undefined || this.phoneRegExp.test(this.model.phone) == false) {
      this.phoneError!.nativeElement.innerHTML = "Не вірний формат номеру телефону (Приклад: +380123456789)";
      valid = false;
    }
    if (this.model.email == undefined || this.emailRegExp.test(this.model.email) == false) {
      this.emailError!.nativeElement.innerHTML = "Не вірний формат електронної пошти (Приклад: email@example.com)";
      valid = false;
    }
    if (this.model.login == undefined) {
      this.loginError!.nativeElement.innerHTML = "Логін не може бути пустим";
      valid = false;
    } else if (this.model.login.length < 3) {
      this.loginError!.nativeElement.innerHTML = "Логін не може бути коротшим за 4 символи";
      valid = false;
    }

    if (this.model.password == undefined || this.model.password.length == 0) {
      this.passwordError!.nativeElement.innerHTML = "Пароль не може бути пустим";
      valid = false;
    } else if (this.model.password.length < 8) {
      this.passwordError!.nativeElement.innerHTML = "Пароль не може бути коротшим за 8 символів";
      valid = false;
    } else if (this.model.password != this.model.passwordConfirm) {
      this.passwordError!.nativeElement.innerHTML = "Паролі не співпадають";
      valid = false;
    }

    if (valid) {
      console.log(this.model);
    }
  }

  onChangeEmail(): void {
    this.emailError!.nativeElement.innerHTML = '';
    if (this.model.email == undefined || this.emailRegExp.test(this.model.email) == false) {
      this.emailError!.nativeElement.innerHTML = "Не вірний формат електронної пошти (Приклад: email@example.com)";
    }
  }

  onChangePhone(): void {
    this.phoneError!.nativeElement.innerHTML = '';
    if (this.model.phone == undefined || this.phoneRegExp.test(this.model.phone) == false) {
      this.phoneError!.nativeElement.innerHTML = "Не вірний формат номеру телефону (Приклад: +380123456789)";
    }
  }

  clearError(element: HTMLSpanElement): void {
    element.innerHTML = '';
  }
}
