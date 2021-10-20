import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
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
