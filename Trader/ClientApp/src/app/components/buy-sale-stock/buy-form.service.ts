import { DecimalPipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {BuySell} from 'src/models/BuySell'
import { StockPrice } from 'src/models/StockPrice';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BuyFormService {
  UserId: number;
  StockSymbol: string;
  Price: DecimalPipe;
  Quantity: number;
  total: DecimalPipe;
  TransactionType:string;
  datetime: Date;

  myAppURL= 'http://localhost:50392/';
  
  constructor(private http:HttpClient) {
 
  }
  ngOnInit() {
    this.datetime = new Date();

  }
  GetStockPriceByStockSymbol(StockSymbol): Observable<StockPrice> {
    return this.http.get<StockPrice>(this.myAppURL + 'api/GetStockPriceByStockSymbol?StockSymbol=' + StockSymbol);
  }

  BuySaleStockByUserID(paraBuySale, UserId): Observable<any>{
       return this.http.post(this.myAppURL + 'api/PostBuySaleStockByUserID?UserId=' +UserId+'&StockSymbol='+ paraBuySale.StockSymbol
       +'&Price='+paraBuySale.price + '&Quantity='+paraBuySale.quantity + '&Total='+ paraBuySale.price * paraBuySale.quantity
       +'&TransactionType=' +paraBuySale.transaction, httpOptions);
       }

  // BuySaleStockByUserID(paraBuySale, UserId): Observable<any>{
  //   return this.http.post(this.myAppURL + 'api/PostBuySaleStockByUserID', {
  //     UserId: 2,
  //     StockSymbol: paraBuySale.StockSymbol,
  //     Price: paraBuySale.price,
  //     Quantity: paraBuySale.quantity,
  //     total: paraBuySale.price * paraBuySale.quantity,
  //     TransactionType: paraBuySale.transaction,
  //     datetime: '2020-11-23' }, httpOptions);
  //   }
}
