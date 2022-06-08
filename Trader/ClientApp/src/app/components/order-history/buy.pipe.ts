import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'buy'
})
export class BuyPipe implements PipeTransform {

  transform(True: boolean, False: boolean): any {
    if (True)
    return "Buy";
    else
    return "Sell";
  }

}
