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

  isSubmitted: boolean = false;

  myAccounts: any;

  selectedAcc: any;

  maxDepo: number = 0;

  constructor(private accountSvc: AccountService,
            private alertService: AlertService,
            private router: Router) { }

  ngOnInit(): void {

    const myEmail = localStorage.getItem('email') ?? "";
    this.accountSvc.getAccountsOfClientByEmail(myEmail).subscribe(data => {
      this.myAccounts = data;

      console.log('all accounts: ' + JSON.stringify(this.myAccounts));
    })

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
    

    this.maxDepo = selAccount.split(':')[1].replace('$','');

    alert('Selected: ' + JSON.stringify(selAccount) + ' | Max: ' + this.maxDepo);
  }


}
