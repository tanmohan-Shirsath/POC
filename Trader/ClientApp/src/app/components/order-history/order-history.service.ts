import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Orderhistory} from 'src/models/Orderhistory'
@Injectable({
  providedIn: 'root'
})
export class OrderHistoryService {

  Orderhistory:[];
  
myAppURL= 'http://localhost:50392/';
  
  constructor(private http:HttpClient) {
 
  }

  GetOrderHistoryByUserID(UserId):Observable <Orderhistory[] >{
    //console.warn('Your User ID in service:- ', UserId);
    return this.http.get<Orderhistory[]>(this.myAppURL+'api/GetOrderHistoryByUserID?UserId='+UserId);
   
  
  }
}
