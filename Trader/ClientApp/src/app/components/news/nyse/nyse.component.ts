import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { observable, pipe } from 'rxjs';
import { News } from 'src/models/news';
import {NyseService} from '../nyse/nyse.service';
// import {Ng2SearchPipeModule} from 'ng2-search-filter';

// @pipe
// Ng2SearchPipeModule,
// ({})
@Component({
  selector: 'app-nyse',
  templateUrl: './nyse.component.html',
  styleUrls: ['./nyse.component.css']
})
export class NyseComponent implements OnInit {
  NewsList;
  currentUser: any;
  searchText: any;
  // url: string = 'http://localhost:50392/api/GetNyseNews';
  // NewsArray:[];
  constructor(private mynyseService: NyseService,private _http: HttpClient) {
  
  }

  ngOnInit() {    
   this.mynyseService.getNyseNews().subscribe((data) => {
  this.NewsList = data;
});
  }

}
