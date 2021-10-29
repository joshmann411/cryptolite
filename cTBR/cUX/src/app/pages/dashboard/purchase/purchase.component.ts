import { Component, Input, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit(): void {
  }

  toggleSubmit(){
    this.isSubmitted = true;
  }


}
