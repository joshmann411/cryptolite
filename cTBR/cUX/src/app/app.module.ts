import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ProgressbarService } from './shared/services/progressbar.service';
import { MatStepperModule } from '@angular/material/stepper';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { LayoutSideModule } from './layouts/layout-side/layout-side.module';
import { LayoutFullModule } from './layouts/layout-full/layout-full.module';
import { HomeComponent } from './pages/home/home.component';
import { RowExampleComponent } from './pages/row-example/row-example.component';
import { ColExampleComponent } from './pages/col-example/col-example.component';


@NgModule({
  declarations: [ 
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    LayoutSideModule,
    LayoutFullModule,
    AuthModule,
    MatTableModule,
    CommonModule,
    FontAwesomeModule,
    RouterModule,
    MatSidenavModule,
    FlexLayoutModule,
    // AlertModule.forRoot({maxMessages: 5, timeout: 5000, positionX: 'right'})
    MatStepperModule
  ],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { displayDefaultIndicatorType: false }
    },
    ProgressbarService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
