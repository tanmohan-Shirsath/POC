import { Component, OnInit } from '@angular/core';
import { MyassetService} from './myasset.service';
import { DataSource} from '@angular/cdk/collections';
import { PortFolio} from 'src/models/PortFolio';
import { Observable } from 'rxjs';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';

@Component({
  selector: 'app-my-asset',
  templateUrl: './my-asset.component.html',
  styleUrls: ['./my-asset.component.css']
})
export class MyAssetComponent implements OnInit {
 // tslint:disable-next-line: no-use-before-declare
 dataSource = new PortFolioDataSource(this.myasset, this.token);
 displayedColumns = ['stockSymbol', 'stockCompanyName', 'remainingQuantity', 'price', 'total','accountValue','profitloss'];
  currentUser: any;
  UserId: any;
  myDate = new Date();

  
  // tslint:disable-next-line: no-shadowed-variable
  constructor( private myasset: MyassetService,private token: TokenStorageService) { }

  ngOnInit() {
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;
  }

}

export class PortFolioDataSource extends DataSource<any> {
  UserId:any;
  currentUser: any;
  constructor (private myasset: MyassetService, private token: TokenStorageService) {
    super();
    this.currentUser = this.token.getUser();
    this.UserId = this.currentUser.userId;
  }

  connect(): Observable<PortFolio[]> {

    return this.myasset.getmyassetByUserID(this.UserId);
  }

  disconnect() {}
}
