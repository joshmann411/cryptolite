import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  readonly authUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  getClientByEmail(email: string): Observable<any> {
    return this.http.get<any>(
      this.authUrl + 'Client/GetClientByEmail/' + email, this.getHttpOptions()
    );
  }

  UpdateClientDetails(val: any): Observable<any>{
    const body = val;

    //alert('BODY to send: ' + JSON.stringify(body));

    return this.http.put<any>(  
        this.authUrl + 'Client/UpdateClientDetail', body, this.getHttpOptions()
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
