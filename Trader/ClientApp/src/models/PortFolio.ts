import { DecimalPipe } from "@angular/common";

export interface PortFolio {
     StockSymbol: any;
     StockCompanyName: any;
     Quantity: any;
     Price: any;
     Commision:number;
     Total:number;
     AccountValue:number;
     DateTime:Date;
     profitloss :DecimalPipe;
}
