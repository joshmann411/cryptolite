import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutFullComponent } from './layouts/layout-full/layout-full.component';
import { LayoutSideComponent } from './layouts/layout-side/layout-side.component';
import { ColExampleComponent } from './pages/col-example/col-example.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { ResetPasswordComponent } from './pages/reset-password/reset-password.component';
import { RowExampleComponent } from './pages/row-example/row-example.component';

const routes: Routes = [
  {
    path: '',
    //add routes here when you want
    //a layout without a sidebar
    component: LayoutFullComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
      },
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
      {path: 'reset-password', component: ResetPasswordComponent},
      {path: 'dashboard', component: DashboardComponent}
    ],
  },
  {
    path: '',
    component: LayoutSideComponent,
    children: [
      {
        //add routes here when you want
        // a layout with a sidebar
        path: 'row-examples',
        component: RowExampleComponent,
      },
      {
        path: 'col-examples',
        component: ColExampleComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
