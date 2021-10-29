import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertUSDToBTC'
})
export class ConvertUSDToBTCPipe implements PipeTransform {

  transform(usdValue: number, coinCode: any): number {
    
    
    //BTC Conversion
    if(usdValue > 0 && coinCode == 'BTC'){
      return usdValue * 0.000016;
    }
    //ETH Conversion
    else if(usdValue > 0 && coinCode == 'ETH'){
      return usdValue * 0.000226;
    }
    //XRP Conversion
    else if(usdValue > 0 && coinCode == 'XRP')
    {
      return usdValue * 0.93;
    }
    //LTE Conversion    
    else if(usdValue > 0 && coinCode == 'LTE')
    {
      return usdValue * 0.0051;
    }
    //ADA Conversion
    else if(usdValue > 0 && coinCode == 'ADA'){
      return usdValue * 0.49751243781094534;
    }
    //XLM Conversion
    else if(usdValue > 0 && coinCode == 'XLM'){
      return usdValue * 2.8026827279071527;
    }
    else
    {
      return 0;
    }
  }

}
