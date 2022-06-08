import { DecimalPipe } from "@angular/common";

export class BuySell {
   UserId: number;
   StockSymbol:string;
   Price:DecimalPipe;
   Quantity:DecimalPipe;
   total:number;
   TransactionType:string;
   datetime: Date;
}