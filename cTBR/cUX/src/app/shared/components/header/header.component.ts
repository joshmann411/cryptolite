import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgProgress } from 'ngx-progressbar';
import { ProgressbarService } from '../../services/progressbar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
      private router: Router,
      private progress: NgProgress,
      public progressBar: ProgressbarService) { }


  ngOnInit() {
    this.progressBar.progressRef = this.progress.ref('progressBar');
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

}
