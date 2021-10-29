import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-wallet',
  templateUrl: './add-edit-wallet.component.html',
  styleUrls: ['./add-edit-wallet.component.css']
})
export class AddEditWalletComponent implements OnInit {

  @Input() wallet: any;

  constructor() { }

  ngOnInit(): void {
  }

}
