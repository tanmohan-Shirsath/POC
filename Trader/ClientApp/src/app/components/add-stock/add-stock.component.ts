import { Component, OnChanges, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BuyFormService } from '../buy-sale-stock/buy-form.service';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';
import { AddstockService } from './addstock.service';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrls: ['./add-stock.component.css']
})
export class AddStockComponent implements OnInit {
  stockPriceForm: any;
  currentUser: any;
  UserId: any;
  returnVal: any;

  constructor(
    private addstockService: AddstockService,
    private formBuilder: FormBuilder,
    private token: TokenStorageService) {
      this.stockPriceForm = this.formBuilder.group({
        date: '',
        stockSymbol: '',
        openMarket: '',
        highMarket: '',
        lowMarket: '',
        closeMarket: '',
        volumeOfMarket: ''
      });
     }

  ngOnInit() {
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;
  }
  onSubmit(data) {
    // Process checkout data here
    this.addstockService.AddStockPrice(this.stockPriceForm).subscribe((data => {
      this.returnVal = data;
      console.log('this.returnVal'+ this.returnVal);
    }));
    //this.items = this.buyservice.clearCart();
    this.stockPriceForm.reset();

    //console.warn('Your order has been submitted', data);
  }
  
}
