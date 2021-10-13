import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  // { path: 'posts', component: PostsComponent},
  // { path: 'transfer', component: TransferComponent},
  // { path: 'history', component: TransferHistComponent},
  // { path: 'summary', component: TransferSummComponent},
  // { path: 'msgs', component: MessagesComponent},
  // { path: 'tickets', component: TicketsComponent},
  // { path: 'beneficiaries', component: BeneficiaryComponent},
  // { path: 'accounts', component: AccountsComponent},
  // { path: 'register', component: RegisterComponent},
  // { path: 'login', component: LoginComponent },
  // { path: 'completeProfile', component: ProfilecompleteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
