import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/components/site/_services/tokenstorage.service';

@Component({
  selector: 'app-sidemenu',
  templateUrl: './sidemenu.component.html',
  styleUrls: ['./sidemenu.component.css']
})
export class SidemenuComponent implements OnInit {
  currentUser: any;
  role: any;

  constructor(private token: TokenStorageService) { }

  ngOnInit() {
    this.currentUser = this.token.getUser();
    this.role = this.token.getUser().roles;
    console.log('Role is:-'+ this.role);
  }

}
