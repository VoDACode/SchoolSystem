import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrateUsersComponent } from './administrate.users/administrate.users.component';
import { AppComponent } from './app.component';
import { CreateFirstUserComponent } from './create-first-user/create-first-user.component';
import { DisciplineEditorComponent } from './discipline-editor/discipline-editor.component';
import { GroupsComponent } from './groups/groups.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MyPageComponent } from './my-page/my-page.component';
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
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard], pathMatch: 'full'},
      { path: 'discipline-editor', component: DisciplineEditorComponent, canActivate: [AuthGuard] },
      { path: 'timetable', component: TimetablePageComponent, pathMatch: 'full' },
      { path: 'users', component: AdministrateUsersComponent, canActivate: [AuthGuard], pathMatch: 'full' },
      { path: 'start', component: CreateFirstUserComponent, pathMatch: 'full' },
      { path: 'my', canActivate: [AuthGuard], component: MyPageComponent, children: [
        { path: 'groups', component: GroupsComponent }
      ]}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
