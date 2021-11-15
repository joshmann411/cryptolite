import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AccountService } from 'src/app/shared/services/account.service';

interface Acc {
  AccountId: number;
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

  modalTitle: string = '';
  walletModalTitle: string = '';


  asset: any;

  account: any;

  helper = new JwtHelperService();

  //holds the username of currently logged in user
  userEmail: string;

  //holds accounts of current user
  myAccounts: Acc[] = [];

  //===Variables region ends===


  constructor(private _accountService: AccountService) {
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



  ngOnInit(): void {
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

    this.activateAddEditDashboardCom = false;
    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
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

    this.activateAddEditDashboardCom = true;
  }

  addWalletClick() {
    //wallet = account
    this.account = {
      AccountId: "",
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

    this.activateAddEditAccountPortalCom = true;
  }

  closeClick(){
     this.activateAddEditDashboardCom = false;
      this.activateAddEditAccountPortalCom = false;
      this.activatePurchaseCom = false;
  }

  closeWalletClick(){
    this.activateAddEditDashboardCom = false;
    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;
  }

  editClick(selAsset: any){
    this.asset = selAsset;
    this.modalTitle = "Edit Asset";

    this.activateAddEditAccountPortalCom = false;
    this.activatePurchaseCom = false;

    this.activateAddEditDashboardCom = true;
  }

  purchaseClick(selAsset: any){
    // alert('Im here: ' + selAsset.assetName + selAsset.assetShortCode + selAsset.imgPath + selAsset.direction + selAsset.directionPercentage);
    this.asset = selAsset;
    this.modalTitle = "Buy Now";

    this.activateAddEditAccountPortalCom = false;
    this.activateAddEditDashboardCom = false;
    
    this.activatePurchaseCom = true;
  }
}
