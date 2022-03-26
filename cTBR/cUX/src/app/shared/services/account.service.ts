import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  //readonly authUrl = "https://localhost:5201/api/";

  readonly authUrl = "https://api.dynamocryptos.com:5201/api/";


  constructor(private http: HttpClient) { }
  //this method will go create a new account for user x



  //this will go create a new account
  addAccount(val: any)
  {
    return this.http.post(
        this.authUrl + 'Account/Post', val, this.getHttpOptions()
      );
  }

  updateAccount(val: any){
    return this.http.post(
      this.authUrl + 'Account/Put', val, this.getHttpOptions()
    );
  }

  getWallet() : Observable<any> {
    return this.http.get(
      this.authUrl + 'Account/GetWalletAddress', this.getHttpOptions()
    );
  }

  //get the list of accounts - to be decommissoned
  getListOfAccounts() : Observable<any[]> {
    return this.http.get<any>(
      this.authUrl + 'Account/Get', this.getHttpOptions()
    );
  }

  getAccountsOfClientByEmail(clientEmail: any): Observable<any>{
    return this.http.get<any>(this.authUrl + 'Account/GetAccountsOfClientByEmail/' + clientEmail, this.getHttpOptions()); 
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
