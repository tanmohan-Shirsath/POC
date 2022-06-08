import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
 import { PortFolio } from 'src/models/PortFolio';

@Injectable({
  providedIn: 'root'
})
export class MyassetService {
  PortoFolio:[];

  private serviceUrl = 'http://localhost:50392/';
  constructor(private http: HttpClient) { }

  getmyassetByUserID(UserId): Observable<PortFolio[]> {
    return this.http.get<PortFolio[]>(this.serviceUrl + 'api/GetMyAssestByUserID?UserId='+UserId);    
  }
}
