import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {

  @Input() asset: any;

  btc: number = 0;
  dlr: number = 0;

  leastOneIsConfimed: boolean = false;

  isSubmitted: boolean = false;

  myAccounts: any;

  selectedAcc: any;

  maxDepo: number = 0;

  unvalidatedAcctCount: number = 0;

  constructor(private accountSvc: AccountService,
            private alertService: AlertService,
            private router: Router) { }

  ngOnInit(): void {

    const myEmail = localStorage.getItem('email') ?? "";
    this.accountSvc.getAccountsOfClientByEmail(myEmail).subscribe(data => {
      this.myAccounts = data;

      // console.log('all accounts: ' + JSON.stringify(this.myAccounts));
      this.AtLeastOneAccountIsConfirmed();

      this.calcUnvalidated();
    });

    

    // alert('Now least one is confirmed: ' + this.leastOneIsConfimed);

  }

  onSubmit(f: NgForm){
    this.alertService.info('System upgrade in progress...');
    this.alertService.info('Request saved. Processing will be done at a later stage');
    // this._progressSvc.startLoading();
    
    console.log(f.value); //REMOVE 

    window.location.reload();
  }

  toggleSubmit(){
    this.isSubmitted = true;
  }

  acc2Invest(selAccount: any){
    

    this.maxDepo = selAccount.split(':')[1].replace('$','').replace(".00", "");

    // alert('Selected: ' + JSON.stringify(selAccount) + ' | Max: ' + this.maxDepo);
  }

  goToDashboard(){
    //this.router.navigate(['dashboard']);
    window.location.reload();
  }

  AtLeastOneAccountIsConfirmed()
  {

    for (let i = 0; i < this.myAccounts.length; i++) {
      // console.log("Account " + i + ": " + JSON.stringify(this.myAccounts[i]));

      //if one of this happens to be confirmed then show
      if(this.myAccounts[i].isConfirmed){
        this.leastOneIsConfimed = true;
      }
    }

    // alert('Now least one is confirmed: ' + this.leastOneIsConfimed);
  }

  calcUnvalidated(){
    let counter = 0

    for(let i = 0; i < this.myAccounts.length; i++){
      if(!this.myAccounts[i].isConfirmed){
        counter++;
      }
    }
    // this.alertService.info('counter: ' + counter);

    this.unvalidatedAcctCount = counter;
  }

  
}
