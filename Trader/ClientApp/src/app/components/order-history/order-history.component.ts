import { DataSource } from '@angular/cdk/table';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Orderhistory } from 'src/models/Orderhistory';
import { OrderHistoryService } from './Order-history.service';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {
  
  Orderhistory:[];
  UserId:any;
  myDate= new Date();
  //Method for data collection from templete
  dataSource = new OrderHistoryDataSource (this.myOrderhistoryService, this.token);
  displayedOrderHistory = ['dateTime', 'transactionType', 'stockSymbol', 'quantity', 'price', 'commision', 'total', 'accountValue'];
  currentUser: any;

  constructor(private myOrderhistoryService:OrderHistoryService, private token: TokenStorageService) { 

  }
  ngOnInit() {    
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;    
  }

}

export class OrderHistoryDataSource extends DataSource<any>{

  UserId:any;
  currentUser: any;

  constructor(private myOrderhistoryService: OrderHistoryService , private token: TokenStorageService) {
    super();
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;
   }

 connect(): Observable<Orderhistory[]> 
 {
  //console.warn('Your User ID in connect', this.UserId);
   return this.myOrderhistoryService.GetOrderHistoryByUserID(this.UserId);
 }

 disconnect() {}
}
