import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authUrl = "http://localhost:50175/api/Identity/";
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

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.authUrl + 'login', model).pipe(
      map((response: any) => {
        //temp
        this.isLoggedIn = response.result.succeeded;
        this.currentUser.username = response.username;
        this.currentUser.email = response.email;

        localStorage.setItem('token', response.token);

        return this.currentUser;
      })
    )
  }

  logout(){
    this.isLoggedIn = false;
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

  loggedIn(): boolean {
    const token = localStorage.getItem('token') ?? '';

    // console.log('Token: ' + token);

    return !this.helper.isTokenExpired(token);
  }

}
