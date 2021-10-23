import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
          private alertService: AlertService) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {
    // console.log(f.value);  // { first: '', last: '' }
    // console.log(f.valid);  // false
    this.alertService.info('New account creation in progress...');
    this.progressBar.startLoading();
    const registerObserver = {  
      next: (x: any) => {
        this.progressBar.setSuccess();
        console.log('User Created');
        this.progressBar.completeLoading();
        this.alertService.success('Account created successfully.');
      },
      error: (err: any) => {
        this.progressBar.setError();
        console.error(err);
        this.progressBar.completeLoading();
        this.alertService.danger(err.error.Errors[0].Description);
      }
    };

    this.authService.register(f.value).subscribe(registerObserver);
  }

}
