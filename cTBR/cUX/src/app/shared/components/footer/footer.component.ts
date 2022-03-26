import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit(): void {
  }

  goToDashboard(){
    this.router.navigate(['dashboard']);
  }

  goToTerms(){
    this.router.navigate(['terms']);
  }

  goToPrivacy(){
    this.router.navigate(['privacy']);
  }
}
