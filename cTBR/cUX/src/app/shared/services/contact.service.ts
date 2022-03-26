import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  //readonly authUrl = "https://localhost:5201/api/";
  
  readonly authUrl = "https://api.dynamocryptos.com:5201/api/";

  constructor(private http: HttpClient) { }

  sendMessage(val: any)
  {
    return this.http.post(
        this.authUrl + 'Contact/WriteContactUsToFile', val, this.getHttpOptions()
      );

  }

  getHttpOptions(){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };

    return httpOptions;
  } 
}
