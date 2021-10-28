import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-show-dashboard',
  templateUrl: './show-dashboard.component.html',
  styleUrls: ['./show-dashboard.component.css']
})
export class ShowDashboardComponent implements OnInit {
  assetList: any = [];

  activateAddEditDashboardCom: boolean = false;
  modalTitle: string = '';
  asset: any;

  constructor() { }

  ngOnInit(): void {
    this.assetList = [
      {
        assetName: "Bitcoin",
        assetShortCode: "BTC",
        imgPath: "../../../../assets/images/btc2.jfif",
        direction: "up",
        directionPercentage: "0.04%"
      },
      {
        assetName: "Ethereum",
        assetShortCode: "ETH",
        imgPath: "../../../../assets/images/eth.png",
        direction: "up",
        directionPercentage: "0.24%"
      },
      {
        assetName: "Ripple",
        assetShortCode: "XRP",
        imgPath: "../../../../assets/images/ripple.svg",
        direction: "up",
        directionPercentage: "0.33%"
      },
      {
        assetName: "Litecoin",
        assetShortCode: "LTE",
        imgPath: "../../../../assets/images/litecoin.png",
        direction: "up",
        directionPercentage: "0.28%"
      },
      {
        assetName: "Cardano",
        assetShortCode: "ADA",
        imgPath: "../../../../assets/images/cardano.png",
        direction: "up",
        directionPercentage: "0.08%"
      },
      {
        assetName: "Stellar Lumens",
        assetShortCode: "XLM",
        imgPath: "../../../../assets/images/xlm.png",
        direction: "up",
        directionPercentage: "0.48%"
      },
    ]
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
    this.activateAddEditDashboardCom = true;
  }

  closeClick(){
    this.activateAddEditDashboardCom = false;
  }

  editClick(selAsset: any){
    this.asset = selAsset;
    this.modalTitle = "Edit Asset";
    this.activateAddEditDashboardCom = true;
  }

  purchaseClick(selAsset: any){
    // alert('Im here: ' + selAsset.assetName + selAsset.assetShortCode + selAsset.imgPath + selAsset.direction + selAsset.directionPercentage);
    this.asset = selAsset;
    this.modalTitle = "View/Purchase Asset";
    this.activateAddEditDashboardCom = true;
  }
}
