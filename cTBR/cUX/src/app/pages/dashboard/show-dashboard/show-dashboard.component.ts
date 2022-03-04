import { Component, HostListener, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlertService } from 'ngx-alerts';
import { AccountService } from 'src/app/shared/services/account.service';
import { ClientService } from 'src/app/shared/services/client.service';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';

interface Acc {
  AccoutId: number;
  email: string;
  accType: string;
  AccoutName: string;
  MinDeposit: number;
  CurrentAmount: number
  clientId: number;
}

@Component({
  selector: 'app-show-dashboard',
  templateUrl: './show-dashboard.component.html',
  styleUrls: ['./show-dashboard.component.css']
})
export class ShowDashboardComponent implements OnInit {
  //===Variables Region===
  assetList: any = [];

  //coin modal activator
  activateAddEditDashboardCom: boolean = false;

  //Account modal activator
  activateAddEditAccountPortalCom: boolean = false;

   //coin modal activator
   activatePurchaseCom: boolean = false;

   //deposit modal activator (if you already have an account)
   activateDepositCom: boolean = false;

  modalTitle: string = '';
  walletModalTitle: string = '';


  asset: any;

  account: any;

  depWithAccount: any;

  helper = new JwtHelperService();

  //holds the username of currently logged in user
  userEmail: string;

  //holds accounts of current user
  myAccounts: Acc[] = [];


  innerWidth: any;
  //===Variables region ends===

  //hold client info
  thisClient: any;

  //hold model binding
  clientFirstname: any;
  clientLastname: any;
  clientEmail: any;
  clientPhone: any;

  constructor(
      private _accountService: AccountService,
      private alertService: AlertService,
      private progressService: ProgressbarService,
      private clientService: ClientService) {
    const token = localStorage.getItem('token')??'';

    const decodedToken = this.helper.decodeToken(token);

    //extract information form decoded token     
    this.userEmail = decodedToken.email;
    
    console.log('User Email: ' + this.userEmail);


    //make client service : data ready
    //clientService.getClientByEmail(this.clientEmail);

    //go fetch the accounts of the currently logged in user
    // this._accountService.getAccountsOfClientByEmail(this.userEmail).subscribe(data => {
    //   this.myAccounts = data;
    //   console.log('first account: ' + this.myAccounts[0].AccoutName);
    //   console.log('Length of my account: ' + this.myAccounts?.length);
    // });
    
   }


   @HostListener('window:resize', ['$event'])
    onResize(event: any) {
      this.innerWidth = window.innerWidth;
    }


  ngOnInit(): void {

    this.innerWidth = window.innerWidth;

    //dummy data for list of assets
    this.assetList = [
      {
        assetName: "Bitcoin",
        assetShortCode: "BTC",
        imgPath: "../../../../assets/images/svgs/bitcoin.svg",        
        // imgPath: "../../../../assets/images/btc2.jfif",
        direction: "up",
        directionPercentage: "0.04%",
        price: "61,313.92"
      },
      {
        assetName: "Ethereum",
        assetShortCode: "ETH",
        imgPath: "../../../../assets/images/eth.png",
        direction: "up",
        directionPercentage: "0.24%",
        price: "2,786.61"
      },
      {
        assetName: "Ripple",
        assetShortCode: "XRP",
        imgPath: "../../../../assets/images/svgs/ripple.svg",
        direction: "up",
        directionPercentage: "0.33%",
        price: "1.17"
      },
      {
        assetName: "Litecoin",
        assetShortCode: "LTE",
        imgPath: "../../../../assets/images/svgs/litecoin.svg",
        direction: "up",
        directionPercentage: "0.28%",
        price: "191.41"
      },
      {
        assetName: "Cardano",
        assetShortCode: "ADA",
        imgPath: "../../../../assets/images/svgs/cardano.svg",
        direction: "up",
        directionPercentage: "0.08%",
        price: "1.17"
      },
      {
        assetName: "Stellar Lumens",
        assetShortCode: "XLM",
        imgPath: "../../../../assets/images/svgs/stellar.svg",
        direction: "up",
        directionPercentage: "0.48%",
        price: "0.411604"
      },
    ]
  
    //go fetch the accounts of the currently logged in user
    this._accountService.getAccountsOfClientByEmail(this.userEmail).subscribe(data => {
      this.myAccounts = data;
      console.log('first account: ' + this.myAccounts[0].AccoutName);
      console.log('Length of my account: ' + this.myAccounts?.length);
    });

    //fetch the client information
    this.clientService.getClientByEmail(this.userEmail).subscribe(data => {
      this.thisClient = data;

      console.log('Profile Details From Endpoint: ' + JSON.stringify(this.thisClient));


      //if (condition) ? (apply this) : (apply that)

      //if client has a firstname and the firstname is not empty
      this.clientFirstname = (
                                (this.thisClient.firstname?.toLowerCase() != 'null') && 
                                (this.thisClient.firstname != '')
                              ) ? this.thisClient.firstname : 'Enter Firstname';


      this.clientLastname = (
                                (this.thisClient.lastname?.toLowerCase() != 'null') && 
                                (this.thisClient.lastname != '')
                              ) ? this.thisClient.lastname : 'Enter Lastname';

      this.clientEmail = (
                            (this.thisClient.email?.toLowerCase() != 'null') && 
                            (this.thisClient.email != '')
                          ) ? this.thisClient.email : 'Enter email address';
      
      
      this.clientPhone = (
                            (this.thisClient.phone?.toLowerCase() != 'null') && 
                            (this.thisClient.phone != '')
                          ) ? this.thisClient.phone : 'Enter Phone number';

      //alert('I am: ' + JSON.stringify(this.thisClient))
      // alert('firstname: '+ this.clientFirstname + ' | lastname: ' + this.clientLastname);
    })

    this.activateAddEditDashboardCom = false;
    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
  }

  OnSubmit(f: NgForm){
    //take the values
    // console.log('Profile Details: ' + JSON.stringify(f.value));

    if(
      !f.value.firstname.includes('Enter Firstname') && 
      !f.value.lastname.includes('Enter Lastname')){

        //id, and other attributes should still be intact
        this.thisClient.firstname = f.value.firstname ?? 'NULL';
        this.thisClient.lastname = f.value.lastname ?? 'NULL';
        this.thisClient.email = f.value.email ?? 'NULL';
        this.thisClient.phone = f.value.phone ?? 'NULL';
      
    
        //update the client information

        this.alertService.info('Profile update in progress');
        this.progressService.startLoading();


        const depositIntoAccountObserver = {  
          next: (x: any) => { 
            this.progressService.setSuccess();
            // console.log('New Account Created');
            this.progressService.completeLoading();
            this.alertService.success('Deposit saved!');
            // this.router.navigate(['dashboard']);
            // window.location.reload();
          },
          error: (err: Error) => {
            this.progressService.setError();
            console.error(err);
            this.progressService.completeLoading();
            this.alertService.danger('Deposit not successful');
          }
        };
      
      
      
        // alert('Subittion: ' + JSON.stringify(this.thisClient));
      
        this.clientService.UpdateClientDetails(this.thisClient).subscribe(data => {
          // alert('Returned: ' + JSON.stringify(data));
          this.progressService.completeLoading();
          window.location.reload();
          this.alertService.success('updated successfully');
        })
      }
      else
      {
        this.alertService.danger('Please enter valid details');
      }
    

  }


  removeAccount(acct: any){
    this.alertService.info("Requesting to remove account: " + acct.AccoutName);
    this.alertService.info("Request sent for processing. Our agents will contact you with 72 hours")
  }

  getAccounts(){
    console.log('I am here with data: ' + this._accountService.getListOfAccounts())
    return this._accountService.getListOfAccounts();
  }

  addClick(){
    this.asset = {
      assetName: "",
      assetShortCode: "",
      imgPath: "",
      direction: "",
      directionPercentage: ""
    }

    this.modalTitle = "Add Asset";

    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
    this.activateDepositCom = false;

    this.activateAddEditDashboardCom = true;
  }

  addWalletClick() {
    //wallet = account
    this.account = {
      AccoutId: "",
      email: "",
      accType: "",
      AccoutName: "",
      MinDeposit: "",
      CurrentAmount: "",
      clientId: 0
    }

    this.modalTitle = "Add New Account";

    this.activatePurchaseCom = false;
    this.activateAddEditDashboardCom = false;
    this.activateDepositCom = false;

    this.activateAddEditAccountPortalCom = true;
  }

  closeClick(){
     this.activateAddEditDashboardCom = false;
      this.activateAddEditAccountPortalCom = false;
      this.activatePurchaseCom = false;
      this.activateDepositCom = false;
  }

  closeWalletClick(){
    this.activateAddEditDashboardCom = false;
    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
    this.activateDepositCom = false;
  }

  editClick(selAsset: any){
    this.asset = selAsset;
    this.modalTitle = "Edit Asset";

    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
    this.activateDepositCom = false;

    this.activateAddEditDashboardCom = true;
  }

  purchaseClick(selAsset: any){
    // alert('Im here: ' + selAsset.assetName + selAsset.assetShortCode + selAsset.imgPath + selAsset.direction + selAsset.directionPercentage);
    this.asset = selAsset;
    this.modalTitle = "Buy Now";

    this.activateAddEditAccountPortalCom = false;
    this.activateAddEditDashboardCom = false;
    this.activateDepositCom = false;
    
    this.activatePurchaseCom = true;
  }

  makeDeposit(action: string, AccId: any, SelAccount: any){
    if(action == 'Deposit'){
      //build account obj
      this.depWithAccount = {
        AccoutId: SelAccount.AccoutId,
        email: SelAccount.email,
        accType: SelAccount.accType,
        AccoutName: SelAccount.AccoutName,
        MinDeposit: SelAccount.MinDeposit,
        CurrentAmount: SelAccount.CurrentAmount,
        clientId: SelAccount.clientId,
        Action: action
      }

      // alert('Selected Account: ' + JSON.stringify(this.account));


      this.modalTitle = "Deposit";

      this.activateAddEditAccountPortalCom = false;
      this.activateAddEditDashboardCom = false;
      this.activatePurchaseCom = false; 
      
      this.activateDepositCom = true;
    }
    else{
      alert('Contact Admin to process withdrawal');

      window.location.reload();
    }
  }
}
