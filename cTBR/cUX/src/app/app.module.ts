import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
import { MatButtonModule } from '@angular/material/button';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { LayoutSideModule } from './layouts/layout-side/layout-side.module';
import { LayoutFullModule } from './layouts/layout-full/layout-full.module';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './pages/register/register.component';
import { ResetPasswordComponent } from './pages/reset-password/reset-password.component';
import { MaterialModule } from './material/material.module';
import { AuthModule } from './auth/auth.module';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { MatCardModule } from '@angular/material/card';
import { ShowDashboardComponent } from './pages/dashboard/show-dashboard/show-dashboard.component';
import { AddEditDashboardComponent } from './pages/dashboard/add-edit-dashboard/add-edit-dashboard.component';
import { MatTabsModule } from '@angular/material/tabs';
import { AddEditWalletComponent } from './pages/dashboard/add-edit-wallet/add-edit-wallet.component';
import { PurchaseComponent } from './pages/dashboard/purchase/purchase.component';
import { ConvertUSDToBTCPipe } from './pages/dashboard/purchase/convert-usdto-btc.pipe';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DepositComponent } from './pages/dashboard/deposit/deposit.component';
import { PrivacyComponent } from './pages/privacy/privacy.component';
import { TermsComponent } from './pages/terms/terms.component';
import { FormatCardNumberPipe } from './pages/dashboard/show-dashboard/format-card-number.pipe';
import { ClipboardModule } from 'ngx-clipboard';

@NgModule({
  declarations: [ 
    AppComponent,  
    LoginComponent, 
    RegisterComponent, 
    ResetPasswordComponent, 
    DashboardComponent,
    ShowDashboardComponent,
    AddEditDashboardComponent,
    AddEditWalletComponent,
    PurchaseComponent,
    ConvertUSDToBTCPipe,
    DepositComponent,
    PrivacyComponent,
    TermsComponent,
    FormatCardNumberPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    LayoutSideModule,
    LayoutFullModule,
    HttpClientModule,
    MatTableModule,
    CommonModule,
    FontAwesomeModule,
    RouterModule,
    MatSidenavModule,
    FlexLayoutModule,
    FormsModule,
    MatStepperModule,
    AuthModule,
    MaterialModule,
    MatCardModule,
    MatTabsModule,
    MatButtonModule,
    MatFormFieldModule,
    ClipboardModule 
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
