import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrateUsersComponent } from './administrate.users/administrate.users.component';
import { AppComponent } from './app.component';
import { CreateFirstUserComponent } from './create-first-user/create-first-user.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './services/AuthGuard';
import { TimetablePageComponent } from './timetable.page/timetable.page.component';

const routes: Routes = [
  {
    path: '', component: AppComponent, children: [
      {
        path: 'auth', children: [
          { path: 'login', component: LoginComponent, pathMatch: 'full' }
        ]
      },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard], pathMatch: 'full' },
      { path: 'timetable', component: TimetablePageComponent, pathMatch: 'full' },
      { path: 'users', component: AdministrateUsersComponent, canActivate: [AuthGuard], pathMatch: 'full' },
      { path: 'start', component: CreateFirstUserComponent, pathMatch: 'full' }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
