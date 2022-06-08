import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class HeaderService {
  UserId:'';
  private serviceUrl = 'http://localhost:50392/';
  constructor(private http:HttpClient) { }

    GetUserBalanceByUserID(UserId):Observable<any> {

    return this.http.get<any>(this.serviceUrl + 'api/GetUserBalanceByUserID?UserId='+UserId);
  }
    
}
