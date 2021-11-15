import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  readonly authUrl = "http://localhost:50175/api/";

  constructor(private http: HttpClient) { }

  getClientByEmail(email: string): Observable<any> {
    return this.http.get<any>(
      this.authUrl + 'Client/GetClientByEmail/' + email, this.getHttpOptions()
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
