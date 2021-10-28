import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-dashboard',
  templateUrl: './add-edit-dashboard.component.html',
  styleUrls: ['./add-edit-dashboard.component.css']
})
export class AddEditDashboardComponent implements OnInit {

  @Input() asset: any;
  
  constructor() { }

  ngOnInit(): void {
  }

}
