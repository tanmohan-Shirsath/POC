import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { SidemenuComponent } from './components/layout/sidemenu/sidemenu.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { HomeComponent } from './components/site/home/home.component';
import { ChartsComponent } from './components/site/charts/charts.component';
import { FormsComponent } from './components/site/forms/forms.component';
import { LoginComponent } from './components/site/login/login.component';
import { RegisterComponent } from './components/site/register/register.component';
import { TablesComponent } from './components/site/tables/tables.component';
import { RouterModule, Routes } from '@angular/router';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { BuySaleStockComponent } from './components/buy-sale-stock/buy-sale-stock.component';
import { MyAssetComponent } from './components/my-asset/my-asset.component';
import { OrderHistoryComponent } from './components/order-history/order-history.component';
import { StockPriceComponent } from './components/stock-price/stock-price.component';
import { TechAnalysisComponent } from './components/learn/tech-analysis/tech-analysis.component';
import { FundAnalysisComponent } from './components/learn/fund-analysis/fund-analysis.component';
import { NyseComponent } from './components/news/nyse/nyse.component';
import { NasdaqComponent } from './components/news/nasdaq/nasdaq.component';
import { WhatisfundComponent } from './components/learn/fund-analysis/details/whatisfund/whatisfund.component';
import { CalEDITDAComponent } from './components/learn/fund-analysis/details/cal-editda/cal-editda.component';
import { BVCSComponent } from './components/learn/fund-analysis/details/bvcs/bvcs.component';
import { ThreefactModelComponent } from './components/learn/fund-analysis/details/threefact-model/threefact-model.component';
import { MetricsComponent } from './components/learn/fund-analysis/details/metrics/metrics.component';
import { MarketValueDefinitionComponent } from './components/learn/fund-analysis/details/market-value-definition/market-value-definition.component';
import { EconomicDefComponent } from './components/learn/fund-analysis/details/economic-def/economic-def.component';
import { CashflowComponent } from './components/learn/fund-analysis/details/cashflow/cashflow.component';
import { TrendComponent } from './components/learn/tech-analysis/TDetails/trend/trend.component';
import { CandleStickComponent } from './components/learn/tech-analysis/TDetails/candle-stick/candle-stick.component';
import { AVinstockMComponent } from './components/learn/tech-analysis/TDetails/avinstock-m/avinstock-m.component';
import { WhentotriggerComponent } from './components/learn/tech-analysis/TDetails/whentotrigger/whentotrigger.component';
import { FivethingsComponent } from './components/learn/tech-analysis/TDetails/fivethings/fivethings.component';
import { EngulffingComponent } from './components/learn/tech-analysis/TDetails/engulffing/engulffing.component';
import { CashflowPatternComponent } from './components/learn/tech-analysis/TDetails/cashflow-pattern/cashflow-pattern.component';
import { WhatistechComponent } from './components/learn/tech-analysis/TDetails/whatistech/whatistech.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule} from '@angular/forms';
import { NyseService } from './components/news/nyse/nyse.service';
import {MatTableModule} from '@angular/material/table';
import { MyassetService} from './components/my-asset/myasset.service';
import { StockPriceService } from './components/stock-price/stock-price.service';
//import { Server } from 'http';
import { authInterceptorProviders } from './components/site/_helpers/auth.interceptor';
//import { registerContentQuery } from '@angular/core/src/render3/instructions';
import { TokenStorageService } from './components/site/_services/tokenstorage.service';
import { MultiGuard } from './guards/multi.guard';
import { AddStockComponent } from './components/add-stock/add-stock.component'
import { HeaderService } from './components/layout/header/header.service';
import { BuyPipe } from './components/order-history/buy.pipe';


const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent,canActivate:[MultiGuard],
      children :[{path: 'login', component: LoginComponent}]},
  { path: 'home/register', component: RegisterComponent },
  { path: 'charts', component: ChartsComponent },
  { path: 'forms', component: FormsComponent },
  { path: 'tables', component: TablesComponent },
  { path: 'home/forgotPassword', component: ForgotPasswordComponent },
  { path: 'buySaleStock', component: BuySaleStockComponent,canActivate:[MultiGuard] },
  { path: 'stockPrice', component: StockPriceComponent,canActivate:[MultiGuard] },
  { path: 'myAsset', component: MyAssetComponent,canActivate:[MultiGuard] },
  { path: 'orderHistory', component: OrderHistoryComponent,canActivate:[MultiGuard] },
  { path: 'nasdaqnews', component: NasdaqComponent},
  { path: 'nysenews', component: NyseComponent },
  { path: 'techAnalysis', component: TechAnalysisComponent },
  { path: 'fundAnalysis', component: FundAnalysisComponent },
  { path: 'whatisfund' , component: WhatisfundComponent},
  { path: 'threefact-model', component: ThreefactModelComponent},
  { path: 'metrics', component: MetricsComponent},
  { path: 'market-value-definition', component: MarketValueDefinitionComponent },
  {path: 'economic-def' , component: EconomicDefComponent},
  {path: 'cashflow', component: CashflowComponent},
  {path: 'cal-editda', component: CalEDITDAComponent},
  {path: 'bvcs' , component: BVCSComponent},
  {path: 'whatistech' , component: WhatistechComponent },
  {path: 'cashflowpattern' , component: CashflowPatternComponent},
  {path: 'engulffing' , component: EngulffingComponent },
  {path: 'fivethings' , component: FivethingsComponent },
  {path: 'whentotrigger' , component: WhentotriggerComponent},
  {path: 'AVinstockM' , component: AVinstockMComponent },
  {path: 'CandleStick' , component: CandleStickComponent},
  {path: 'Trend' , component: TrendComponent },
  {path: 'addstock', component:AddStockComponent},

   {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidemenuComponent,
    FooterComponent,
    HomeComponent,
    ChartsComponent,
    FormsComponent,
    LoginComponent,
    RegisterComponent,
    TablesComponent,
    ForgotPasswordComponent,
    BuySaleStockComponent,
    StockPriceComponent,
    MyAssetComponent,
    OrderHistoryComponent,
    TechAnalysisComponent,
    FundAnalysisComponent,
    NyseComponent,
    NasdaqComponent,
    WhatisfundComponent,
    CalEDITDAComponent,
    BVCSComponent,
    ThreefactModelComponent,
    MetricsComponent,
    MarketValueDefinitionComponent,
    EconomicDefComponent,
    CashflowComponent,
    TrendComponent,
    CandleStickComponent,
    AVinstockMComponent,
    WhentotriggerComponent,
    FivethingsComponent,
    EngulffingComponent,
    CashflowPatternComponent,
    WhatistechComponent,
    AddStockComponent,
    BuyPipe,  
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatTableModule,
    Ng2SearchPipeModule,
  ],
  providers: [NyseService, MyassetService, StockPriceService,authInterceptorProviders,TokenStorageService,HeaderService],
  bootstrap: [AppComponent],
})
export class AppModule { }
