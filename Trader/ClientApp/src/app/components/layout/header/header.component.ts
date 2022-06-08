import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';
import { HeaderService } from '../header/header.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser: any;
  currUser: any;
  UserId: any;
  UserBalance: any;

  constructor(private token: TokenStorageService, private mybalance: HeaderService ) { }

  ngOnInit() {
    this.currentUser = this.token.getUser().username;
    this.UserId = this.token.getUser().userId;    
   this.mybalance.GetUserBalanceByUserID(this.UserId).subscribe((data => {   
    this.UserBalance = data;
  }));
}
  logout() {
    this.token.signOut();
    window.location.reload();
  }
}
