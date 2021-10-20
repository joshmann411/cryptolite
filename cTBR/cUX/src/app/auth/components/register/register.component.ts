import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';

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

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {
    // console.log(f.value);  // { first: '', last: '' }
    // console.log(f.valid);  // false

    const registerObserver = {  
      next: (x: any) => console.log('User Created'),
      error: (err: Error) => console.error(err)
    };

    this.authService.register(f.value).subscribe(registerObserver);
  }
}
