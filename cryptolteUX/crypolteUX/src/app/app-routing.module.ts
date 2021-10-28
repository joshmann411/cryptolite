import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutFullComponent } from './layouts/layout-full/layout-full.component';
import { LayoutSideComponent } from './layouts/layout-side/layout-side.component';
import { ColExampleComponent } from './pages/col-example/col-example.component';
import { HomeComponent } from './pages/home/home.component';
import { RowExampleComponent } from './pages/row-example/row-example.component';

const routes: Routes = [
  {
        //when you want a layout with NO sidebar => add to children array below
    path: '',
    component: LayoutFullComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
      },
    ],
  },
  {
    //when you want a layout with a sidebar => add to children array below
    path: '',
    component: LayoutSideComponent,
    children: [
      {
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
