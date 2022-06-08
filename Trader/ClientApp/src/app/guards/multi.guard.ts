import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree,Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../components/site/_services/tokenstorage.service';


@Injectable({
  providedIn: 'root'
})
export class MultiGuard implements CanActivate, CanActivateChild, CanLoad {
  currentUser: any;
  constructor(private router:Router,private token: TokenStorageService){
    // console.log("==========Multigurd Service created===========")
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      this.currentUser = this.token.getUser();
      if(this.currentUser !=null)
    return true;
    else {
     this.router.navigate(['/login']);
     return false;
    }
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }
}
