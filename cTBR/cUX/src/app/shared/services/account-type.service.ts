import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountTypeService {

  readonly authUrl = "http://localhost:50175/api/";

  constructor(private http: HttpClient) { }

  getAllTypes(): Observable<any[]>{
    return this.http.get<any>(this.authUrl + 'AccountType/Get', this.getHttpOptions());
  }

  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };

    return httpOptions;
  } 
}
