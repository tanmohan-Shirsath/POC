import { DecimalPipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StockPrice } from 'src/models/StockPrice';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AddstockService {
  myAppURL= 'http://localhost:50392/';

  constructor(private http:HttpClient) { }

  AddStockPrice(StockPrice): Observable<any>{
    return this.http.post(this.myAppURL + 'api/AddStockPrice?date=' +StockPrice.date+'&openMarket='+ StockPrice.openMarket
    +'&highMarket='+StockPrice.highMarket + '&lowMarket='+StockPrice.lowMarket + '&closeMarket='+ StockPrice.closeMarket
    +'&volumeOfMarket=' +StockPrice.volumeOfMarket + '&stockSymbol='+StockPrice.stockSymbol, httpOptions);
    }
}
