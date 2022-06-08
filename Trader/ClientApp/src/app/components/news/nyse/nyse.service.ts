import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { News } from 'src/models/news';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NyseService {
  NewsList: News[];
  myAppUrl = 'http://localhost:50392/';
  newsArray= [];
  constructor(private _http: HttpClient) {
    //  this._http.get(this.myAppUrl + 'api/GetNyseNews').subscribe(data =>{
    //   //populating Array from the News
    //   data.xml().foreach(element =>{
    //     this.newsArray.push(element.title)
    //   })
    //  })
  }

  getNyseNews() {
    return this._http.get(this.myAppUrl + 'api/GetNyseNews');
  }
}
