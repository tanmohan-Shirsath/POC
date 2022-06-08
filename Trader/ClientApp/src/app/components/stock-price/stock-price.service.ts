import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { observable, Observable, Subscriber } from 'rxjs';
import { StockPrice } from 'src/models/StockPrice';
// import { time } from 'console';


@Injectable({
  providedIn: 'root'
})
export class StockPriceService {
  myAppUrl = 'http://localhost:50392/';

  constructor(private _http: HttpClient) {
  }

  GetAllStockPrice(): Observable<StockPrice[]> {
    return this._http.get<StockPrice[]>(this.myAppUrl + 'api/GetAllStockPrice');
  }
  }