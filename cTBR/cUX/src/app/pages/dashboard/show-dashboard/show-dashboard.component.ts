import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-show-dashboard',
  templateUrl: './show-dashboard.component.html',
  styleUrls: ['./show-dashboard.component.css']
})
export class ShowDashboardComponent implements OnInit {
  assetList: any = [];

  //coin modal activator
  activateAddEditDashboardCom: boolean = false;

  //walet modal activator
  activateAddEditWalletPortalCom: boolean = false;

   //coin modal activator
   activatePurchaseCom: boolean = false;

  modalTitle: string = '';
  walletModalTitle: string = '';

  asset: any;

  wallet: any;

  constructor() { }

  ngOnInit(): void {
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
  
    this.activateAddEditDashboardCom = false;
    this.activateAddEditWalletPortalCom = false;
    this.activatePurchaseCom = false;
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

    this.activateAddEditWalletPortalCom = false;
    this.activatePurchaseCom = false;

    this.activateAddEditDashboardCom = true;
  }

  addWalletClick() {
    this.wallet = {
      walletPlan: "",
      AmountHolding: "",
    }

    this.modalTitle = "Add New Wallet";

    this.activatePurchaseCom = false;
    this.activateAddEditDashboardCom = false;

    this.activateAddEditWalletPortalCom = true;
  }

  closeClick(){
     this.activateAddEditDashboardCom = false;
      this.activateAddEditWalletPortalCom = false;
      this.activatePurchaseCom = false;
  }

  closeWalletClick(){
    this.activateAddEditDashboardCom = false;
    this.activateAddEditWalletPortalCom = false;
    this.activatePurchaseCom = false;
  }

  editClick(selAsset: any){
    this.asset = selAsset;
    this.modalTitle = "Edit Asset";

    this.activateAddEditWalletPortalCom = false;
    this.activatePurchaseCom = false;

    this.activateAddEditDashboardCom = true;
  }

  purchaseClick(selAsset: any){
    // alert('Im here: ' + selAsset.assetName + selAsset.assetShortCode + selAsset.imgPath + selAsset.direction + selAsset.directionPercentage);
    this.asset = selAsset;
    this.modalTitle = "Buy Now";

    this.activateAddEditWalletPortalCom = false;
    this.activateAddEditDashboardCom = false;
    
    this.activatePurchaseCom = true;
  }
}
