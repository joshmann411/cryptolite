import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authUrl = "https://localhost:5001/api/Identity/";
  confirmEmailUrl = "test.com";

  // baseurl: string = environment.baseUrl;
  isLoggedIn: boolean = false;

  helper = new JwtHelperService();

  // currentUser: IUser = {
  //   username: null,
  //   email: null
  // };

  currentUser: any = {
    username: null,
    email: null
  };

  constructor(private http: HttpClient,
    private router: Router) { }

  login(model: any){
    return this.http.post(this.authUrl + 'login', model).pipe(
      map((response: any) => {
        //temp
        this.isLoggedIn = response.result.succeeded;
        this.currentUser.username = response.username;
        this.currentUser.email = response.email;

        localStorage.setItem('token', response.token);
        localStorage.setItem('email', response.email);

        return this.currentUser;
      })
    )
  }

  register(model: any){
    let headers = new HttpHeaders({
      'confirmEmailUrl': this.confirmEmailUrl 
    });

    let options = {
      headers: headers
    }
    return this.http.post(this.authUrl + 'register', model, options)
  }

  loggedIn(): boolean{
    const token = localStorage.getItem('token') ?? "";
    return !this.helper.isTokenExpired(token); //not expired = still logged in (true)
  }
 
  logout(): void{
    //go to login page
    this.router.navigate(['login']); 
    
    localStorage?.removeItem('email');
    localStorage?.removeItem('token');
    
    localStorage?.clear;
  }

}
