import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // baseUrl: any = environment.baseUrl;
  isLoggedIn: boolean = false;

  constructor(private http: HttpClient) { }

  login(){
    this.isLoggedIn = true;
  }

  logout(){
    this.isLoggedIn = false;
  }

  register(model: any){
    // return this.http.post(this.baseUrl + 'identity/register', model);
  }

  confirmEmail(model: any){
    return of();
  }

}
