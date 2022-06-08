import { DecimalPipe } from '@angular/common';

export class StockPrice {
    stockSymbol: string;
    CompanyName: string;
    date: Date;
    openMarket: DecimalPipe;
    highMarket: DecimalPipe;
    lowMarket: DecimalPipe;
    closeMarket: DecimalPipe;
    volumeOfMarket: DecimalPipe;
  }
