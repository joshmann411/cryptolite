import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatCardNumber'
})
export class FormatCardNumberPipe implements PipeTransform {

  transform(cardNum: any): any {
     return cardNum.replace(/\s+/g, '').replace(/(\d{4})/g, '$1 ').trim();
  }

}
