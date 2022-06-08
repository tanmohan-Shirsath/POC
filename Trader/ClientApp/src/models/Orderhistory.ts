import { DecimalPipe } from "@angular/common";

export class Orderhistory {
    OrderDate:Date;
    stockSymbol: string;
    quantity:number;
    price:DecimalPipe;
    commision: number;
    total:number;
    accountValue:number;
    transactionType: string;
}