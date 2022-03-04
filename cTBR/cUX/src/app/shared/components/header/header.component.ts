import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { NgProgress } from 'ngx-progressbar';
import { AuthService } from '../../services/auth.service';
import { ProgressbarService } from '../../services/progressbar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  username: any;

  constructor(
      private router: Router,
      private progress: NgProgress,
      private authSvc: AuthService,
      private alertSvc: AlertService,
      public progressBar: ProgressbarService) { }


  ngOnInit() {
    this.progressBar.progressRef = this.progress.ref('progressBar');
     const usrn = localStorage.getItem('username') ?? "";
     this.username = usrn;
  }

  login(){
    console.log('');

    //go to login page
    this.router.navigate(['login']); 
  
  }
  register(){
    console.log('');

    //go to register page
    this.router.navigate(['register']); 
  
    // return this.authService.logout();
  }

  loggedIn(){
    //if token is present, user is still logged in
    console.log('is token there: ' + this.authSvc.loggedIn())
    return this.authSvc.loggedIn();
  }

  logout(){
    this.authSvc.logout();
  }

  notifyProfile(){
    this.alertSvc.info('Select Profile in the tab below');

  }

  notifySettings(){
    this.alertSvc.info('Settings page in DEVELOPMENT. Try again later...');
  }

  notifyActivityLog(){
    this.alertSvc.info('Activity log page in DEVELOPMENT. Try again later...');
  }

}
