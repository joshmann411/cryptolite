import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BillingService {
  //readonly authUrl = "https://localhost:5201/api/";
  
  readonly authUrl = "https://api.dynamocryptos.com:5201/api/";


  constructor(private http: HttpClient) { }

  GetBillings(clientId: any): Observable<any>
  {
    return this.http.get<any>(this.authUrl + 'Billing/GetBillingsLinkedToAccount/' + clientId, this.getHttpOptions());
  }

  addNewCardForClient(model: any){
    return this.http.post(this.authUrl + 'Billing/Post', model, this.getHttpOptions()).pipe(
      map((response: any) => {

        // console.log(response);
        
        return response;
      })
    )
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
