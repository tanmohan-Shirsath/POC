import { Component, OnInit } from '@angular/core';
import {StockPriceService} from '../stock-price/stock-price.service';
import { from, Observable } from 'rxjs';
import {DatePipe} from '@angular/common';
import { observable } from 'rxjs';
import { StockPrice } from 'src/models/StockPrice';
import { DataSource } from '@angular/cdk/table';


@Component({
  selector: 'app-stock-price',
  templateUrl: './stock-price.component.html',
  styleUrls: ['./stock-price.component.css'],
  providers: [DatePipe]
})
export class StockPriceComponent implements OnInit {
  myDate = new Date();
  StockPriceList: any;
  mynewDate: any;

  //Method for templete 
  dataSource = new StockDataSource (this. myStockPriceService);
  displayedstocks = ['CompanyName', 'stockSymbol', 'Date', 'openMarket', 'highMarket', 'lowMarket', 'closeMarket', 'volumeOfMarket'];

  // tslint:disable-next-line: no-shadowed-variable
  
  
  constructor(private datePipe: DatePipe, private myStockPriceService: StockPriceService) {
    const myDate = this.datePipe.transform(this.myDate, 'yyyy-MM-dd');
   }

  ngOnInit() {

     }
  }

  // Exporting the class 

export class StockDataSource extends DataSource<any>{
  mynewDate: any;
  myDate = new Date();
  constructor(private myStockPriceService: StockPriceService) {
    super();
   }

 connect(): Observable<StockPrice[]> 
 {
    
   return this.myStockPriceService.GetAllStockPrice();
 }

 disconnect() {}
}