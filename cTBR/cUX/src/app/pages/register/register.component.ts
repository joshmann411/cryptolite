import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {
    Username: null,
    Email: null,
    Password: null,
    Role: null,
    ClaimTitle: null
  };

  constructor(private authService: AuthService,
          public progressBar: ProgressbarService,
          private router: Router,
          private alertService: AlertService) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {
    // console.log(f.value); 

    this.alertService.info('New account creation in progress...');
    this.progressBar.startLoading();

    const registerObserver = {  
      next: (x: any) => {
        this.progressBar.setSuccess();
        console.log('User Created');
        this.progressBar.completeLoading();
        this.alertService.success('Account created successfully.');
        this.router.navigate(['login']);
      },
      error: (err: any) => {
        this.progressBar.setError();
        console.error(err);
        this.progressBar.completeLoading();
        this.alertService.danger('Error occurred: ' + err.error.Errors[0].Description);
      }
    };

    this.authService.register(f.value).subscribe(registerObserver);
  }

}
