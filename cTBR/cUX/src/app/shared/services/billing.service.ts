import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BillingService {
  readonly authUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  


  getHttpOptions(){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };

    return httpOptions;
  } 
}
