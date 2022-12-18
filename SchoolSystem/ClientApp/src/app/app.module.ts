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
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthInterceptor } from './services/AuthInterceptor';
import { AuthGuard } from './services/AuthGuard';
import { LogoutComponent } from './logout/logout.component';
import { PageNavigatorComponent } from './page-navigator/page-navigator.component';
import { DisciplineEditorComponent } from './discipline-editor/discipline-editor.component';
import { GroupsComponent } from './groups/groups.component';
import { MyPageComponent } from './my-page/my-page.component';

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
    LogoutComponent,
    PageNavigatorComponent,
    DisciplineEditorComponent,
    GroupsComponent,
    MyPageComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ModalModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useFactory: function (router: Router) {
        return new AuthInterceptor(router);
      },
      multi: true,
      deps: [Router]
    },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
