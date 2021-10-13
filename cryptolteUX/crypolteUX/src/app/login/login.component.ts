import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {
    username: null,
    password: null
  };

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm){
    // this.alertService.info('Logging in...');
    // this.progressBar.startLoading();

    const loginObserver = {
      //next: x => {
        // this.progressBar.setSuccess();

        //confirm profile readiness
        //this.GetUsernameAndConfirmProfileReadiness(x.username);

        // if (this.GetUsernameAndConfirmProfileReadiness(x.username)) //ready to rock and roll
        // {
          
        //   this.router.navigate(['accounts']); 
        //   this.alertService.success('Welcom back: ' + x.username);
        //   this.progressBar.completeLoading();
        // }
        // else if(!this.GetUsernameAndConfirmProfileReadiness(x.username)) { //complete your profile please
        //   this.router.navigate(['completeProfile'], {state: {data: {"clientEmail": this.clientEmail}}}); 
        //   this.alertService.info('Incomplete profile detected. Complete before proceeding');
        //   this.progressBar.completeLoading();
        // }
      // },
      // error: err => {
      //   this.progressBar.setError();
      //   console.log(err);
      //   this.alertService.danger('Unable to login !');
      //   this.progressBar.completeLoading();
      // }
    }

    //log in (if everything goes well)
    //this.authService.login(f.value).subscribe(loginObserver);
    
    //call the sidebar service - give side bar its values
    
    //this.LoggedIn = true;
  }


}
