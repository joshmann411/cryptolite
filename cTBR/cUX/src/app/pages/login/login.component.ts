import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  LoggedIn: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    public progressBar: ProgressbarService,
    private alertService: AlertService) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {
    this.alertService.info('Checking user deatails');
    this.progressBar.startLoading();
    const loginObserver = {  
      next: (x: any) => { 
        this.progressBar.setSuccess();
        console.log('User logged in');
        this.progressBar.completeLoading();
        this.alertService.success('Authentication successful.');
        this.router.navigate(['dashboard']);
      },
      error: (err: Error) => {
        this.progressBar.setError();
        console.error(err);
        this.progressBar.completeLoading();
        this.alertService.danger('Authentication failed. Incorrect username and/or password. ');
      }
    };

    //log in (if everything goes well)
    this.authService.login(f.value).subscribe(loginObserver);

    this.LoggedIn = true;
    // console.log(f.value);  // { first: '', last: '' }
    // console.log(f.valid);  // false
  }

  reset()
  {
    //go to reset password page
    this.router. navigate(['reset-password']); 
  }
}
