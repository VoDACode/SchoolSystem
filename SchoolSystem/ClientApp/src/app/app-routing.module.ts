import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrateUsersComponent } from './administrate.users/administrate.users.component';
import { AppComponent } from './app.component';
import { CreateFirstUserComponent } from './create-first-user/create-first-user.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { TimetablePageComponent } from './timetable.page/timetable.page.component';

const routes: Routes = [
  {
    path: '', component: AppComponent, children: [
      {
        path: 'auth', children: [
          { path: 'login', component: LoginComponent }
        ]
      },
      { path: 'home', component: HomeComponent },
      { path: 'timetable', component: TimetablePageComponent },
      { path: 'users', component: AdministrateUsersComponent },
      { path: 'start', component: CreateFirstUserComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
