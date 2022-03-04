import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { AccountService } from 'src/app/shared/services/account.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  @Input() depWithAccount: any;

  maxAmt: number = 10000;

  amount2Add: number = 0; 
  selectedAccId: any;

  selectedAcc: any;

  upAccount: any;

  //holds wallet
  walletAddr: any = '';

  constructor(private _accountSvc: AccountService,
            private _alertService: AlertService,
            private _progressSvc: ProgressbarService,
            private router: Router) { }

  ngOnInit(): void {
    this.selectedAcc = this.depWithAccount;
    this.selectedAccId = this.depWithAccount.AccoutId;

    // console.log('input acc'
  }

  
  onSubmit(f: NgForm){
    this._alertService.info('Deposit in progress');
    this._progressSvc.startLoading();
    
    console.log(f.value); //REMOVE 
    
    const depositIntoAccountObserver = {  
      next: (x: any) => { 
        this._progressSvc.setSuccess();
        // console.log('New Account Created');
        this._progressSvc.completeLoading();
        this._alertService.success('Deposit saved!');
        // this.router.navigate(['dashboard']);
        // window.location.reload();
      },
      error: (err: Error) => {
        this._progressSvc.setError();
        console.error(err);
        this._progressSvc.completeLoading();
        this._alertService.danger('Deposit not successful');
      }
    };

    this.upAccount = {
      AccoutId: f.value.accId,
      email: this.selectedAcc.email,
      accType: this.selectedAcc.accType,
      AccoutName: this.selectedAcc.AccoutName,
      MinDeposit: this.selectedAcc.MinDeposit,
      CurrentAmount: this.selectedAcc.CurrentAmount + f.value.amt2Withdraw,
      clientId: this.selectedAcc.clientId
    }

    console.log('THIS acc: '+ JSON.stringify(this.upAccount));

    this._accountSvc.getWallet().subscribe(data => {
      console.log('wallet address: ' + data);
      this.walletAddr = data
    });
    // this._accountSvc.updateAccount(f.value).subscribe((addAccountObserver)=> {

    // })
  }

  // acc2Append(accId: number){
  //   alert('Selected Acc: ' + accId);
  // }

}
