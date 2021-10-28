import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LayoutFullModule } from './layouts/layout-full/layout-full.module';
import { LayoutSideModule } from './layouts/layout-side/layout-side.module';
// import { HomeComponent } from './pages/home/home.component';
// import { RowExampleComponent } from './pages/row-example/row-example.component';
// import { ColExampleComponent } from './pages/col-example/col-example.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    LayoutFullModule,
    LayoutSideModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
