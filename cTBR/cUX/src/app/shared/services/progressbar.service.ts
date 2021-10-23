import { Injectable } from '@angular/core';
import { NgProgress, NgProgressRef } from 'ngx-progressbar';

@Injectable({
  providedIn: 'root'
})
export class ProgressbarService {
  progressRef: NgProgressRef;
  default: string = "#1B95E0";
  success: string = "#42A948";
  error: string = "#a94442";
  currentColor: string = this.default;
  
  constructor(private progress: NgProgress) { 
    this.progressRef = this.progress.ref();
  }

  startLoading() {
    this.currentColor = this.default;
    this.progressRef.start();
  }

  completeLoading() {
    this.progressRef.complete();
  }

  incLoading(n: number){
    this.progressRef.inc(n);
  }

  setLoading(n: number){
    this.progressRef.set(n);
  }

  setSuccess(){
    this.currentColor = this.success;
  }

  setError(){
    this.currentColor = this.error;
  }
}
