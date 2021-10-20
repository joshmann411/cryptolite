import { ApplicationInitStatus, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AppLayoutComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule
  ],
  exports: [
    AppLayoutComponent
  ]  
})
export class LayoutModule { }
