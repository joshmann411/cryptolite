import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { ContactService } from 'src/app/shared/services/contact.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cuName: any;
  cuEmail: any;
  cuSubject: any;
  cuMessage: any;

  constructor(
    private router: Router,
    private alertService: AlertService,
    private contactService: ContactService) { }

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

  onSubmitContactUs(f: NgForm){

    this.contactService.sendMessage(f.value).subscribe(data => {
      this.alertService.info('Message sent...');
      console.log(data);
      window.location.reload();
    });
    // this.alertService.info('Contact us form values: ' + JSON.stringify(f.value));

    // const dataToSend = {
    //   name: f.value.name,
    //   email: f.value.email,
    //   subject: f.value.subject,
    //   message: f.value.message
    // }

    // this.alertService.info('Contact us Details: ' + JSON.stringify(dataToSend));
  }


}
