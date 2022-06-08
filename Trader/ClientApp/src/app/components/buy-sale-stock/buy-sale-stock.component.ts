import { Component, OnChanges, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BuyFormService } from '../buy-sale-stock/buy-form.service';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';
import {BuySell} from 'src/models/BuySell'
import { SelectorMatcher } from '@angular/compiler';


 @Component({
   selector: 'app-buy-sale-stock',
   templateUrl: './buy-sale-stock.component.html',
   styleUrls: ['./buy-sale-stock.component.css']
 })

export class BuySaleStockComponent {
  alter:boolean=false;
  items;
  checkoutForm;
   currentUser: any;
   UserId:any;
   returnVal:any;
   stockSymbol: any;
   price: any;
  constructor(
    private buyservice: BuyFormService,
    private formBuilder: FormBuilder,
    private token: TokenStorageService
  ) {
    this.checkoutForm = this.formBuilder.group({
      stockSymbol: '',
      price: '',
      transaction: '',
      quantity: '',
      total: ''
    });
  }
  // tslint:disable-next-line: use-lifecycle-interface
  ngOnInit() {
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;
    //this.items = this.buyservice.getItems();

  }

  public onOptionsSelected(event) {   
    const value = event.target.value;
    this.stockSymbol = value;
    this.buyservice.GetStockPriceByStockSymbol(this.stockSymbol).subscribe((data => {
    this.price = data;
    this.checkoutForm.price = this.price;
  }));
  }

  onSubmit(data) {
    // Process checkout data here
    this.buyservice.BuySaleStockByUserID(this.checkoutForm,this.UserId).subscribe((data => {
      this.returnVal = data;
    }));
    this.alter=true;
    this.checkoutForm.reset();
  }
  closeAlert() {

    this.alter=false;
  }
}
