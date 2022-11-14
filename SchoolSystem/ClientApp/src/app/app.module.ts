import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminHomeComponent } from './admin/home/home.component';
import { TeacherHomeComponent } from './teacher/home/home.component';
import { StudentHomeComponent } from './student/home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TimetableComponent } from './timetable/timetable.component';
import { TimetablePageComponent } from './timetable.page/timetable.page.component';
import { ModalModule } from './_modal';
import { AdministrateUsersComponent } from './administrate.users/administrate.users.component';
import { CreateFirstUserComponent } from './create-first-user/create-first-user.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    AppComponent,
    LoginComponent,
    HomeComponent,
    AdminHomeComponent,
    TeacherHomeComponent,
    StudentHomeComponent,
    TimetableComponent,
    TimetablePageComponent,
    AdministrateUsersComponent,
    CreateFirstUserComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ModalModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
