import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, NgForm, FormControl, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { faAngleDoubleDown } from '@fortawesome/free-solid-svg-icons';
import { AlertService } from 'ngx-alerts';
import { AccountTypeService } from 'src/app/shared/services/account-type.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { ClientService } from 'src/app/shared/services/client.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';
import { Account } from './account';

@Component({
  selector: 'app-add-edit-wallet',
  templateUrl: './add-edit-wallet.component.html',
  styleUrls: ['./add-edit-wallet.component.css']
})
export class AddEditWalletComponent implements OnInit {

  @Input() account: any;

  helper = new JwtHelperService();

  genericAccountTypeList: any[] = [];
  AccountType: string = '';
  
   //holds the username of currently logged in user
  userEmail: string = '';

  // current client
  reqClient: any = 0;

  // current client ID
  reqClientId: number = 0;

  //instance of Account class
  AccountModel:any;
 

  minAmt: number = 1;


  model: Account = {
    Email: '',
    AccountType: '',
    AccountName: '',
    CurrentAmount: 0,
    ClientId: 0
  };

  //holds wallet
  walletAddr: any = '';

  constructor(private _accountSvc: AccountService,
              private _accountTypeSvc: AccountTypeService,
              private _clientSvc: ClientService,
              private _progressSvc: ProgressbarService,
              private _alertService: AlertService,
              // private _formBuilder: FormBuilder,
              private router: Router) 
  { 
    this.refreshEmailHolder();
    
    this.refreshClient(); 
  }

  ngOnInit(): void {
    this.refreshEmailHolder();

    //extraction types of accounts 
    this._accountTypeSvc.getAllTypes().subscribe(data => {
      this.genericAccountTypeList = data;

      console.log(this.genericAccountTypeList);
    });
    //extraction ends

    //be ready incase a new acc needs to be added
    this.refreshClient();

    this.AccountModel = new Account(
      this.userEmail,
       '',
       '',
       0,
       this.reqClientId
     );
  }

  onSubmit(f: NgForm){
    console.log(f.value);
    
    this._alertService.info('Checking user deatails');
    this._progressSvc.startLoading();
    // const addAccountObserver = {  
    //   next: (x: any) => { 
    //     this._progressSvc.setSuccess();
    //     console.log('New Account Created');
    //     this._progressSvc.completeLoading();
    //     this._alertService.success('Account created successfully!');
    //     // this.router.navigate(['dashboard']);
    //     // window.location.reload();
    //   },
    //   error: (err: Error) => {
    //     this._progressSvc.setError();
    //     console.error(err);
    //     this._progressSvc.completeLoading();
    //     this._alertService.danger('An error occurred');
    //   }
    // };

    // Process checkout data here
    //console.warn('Your order has been submitted', f.value);
    
    this._accountSvc.addAccount(f.value).subscribe((addAccountObserver)=>
    {
        this._alertService.success('Account created successfully!');
        this._progressSvc.setSuccess();
        console.log('New Account Created');
        this._progressSvc.completeLoading();

        console.log("Exp wallet: " + addAccountObserver)
        this.walletAddr = addAccountObserver.toString().split('|')[1];
    },
    error => {
      this._progressSvc.setError();
      //     console.error(err);
      // console.log();
      // this.router.navigate(['register']); 

      this._alertService.danger("Upload Not successful");
      this._progressSvc.completeLoading();
    });
  }
  
  acc2Open(accInfo: string){
    //extract last 4 chars
    var getAmt = accInfo.split('$');

    this.minAmt = parseInt(getAmt[1].replace(')', '')) ?? 1;

    console.log('Lets see '+ this.minAmt);
    //assign to min val

    console.log(accInfo);
  }

  refreshEmailHolder(){
    //email extraction Operation
    const token = localStorage.getItem('token')??'';

    const decodedToken = this.helper.decodeToken(token);

    //extract information form decoded token     
    this.userEmail = decodedToken.email;
  }

  refreshClient(){
    //Who is making this request (clientId)
    this._clientSvc.getClientByEmail(this.userEmail).subscribe(data => {
      this.reqClient = data;
      this.reqClientId = this.reqClient.id;
     
      console.log("This Client: " + this.reqClient.id);
      console.log("This ClientID : " + this.reqClientId);
    })
  }

  refreshDashboard(){
    window.location.reload();
  }

  onSubmitPayment(f: NgForm){
    console.log('payment values: ' + JSON.stringify(f.value));

    // var acName = acct.AccoutName ?? "";

    if(confirm("Have you made payment to the wallet ? Processing only starts once payment has been received.")) {
      // console.log("Implement delete functionality here");
      this._alertService.info("Payment verification in initiated");
    }
  }

  RequestPaymentInstruction(){
    this._alertService.info('Request received. You will get a email notification shortly.')
  }


}
