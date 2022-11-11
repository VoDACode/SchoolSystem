import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { TimetablePageComponent } from './timetable.page/timetable.page.component';

const routes: Routes = [
  {
    path: 'auth', children: [
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: 'home', component: HomeComponent },
  { path: 'timetable', component: TimetablePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
