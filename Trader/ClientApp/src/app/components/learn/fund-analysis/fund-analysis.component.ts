import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fund-analysis',
  templateUrl: './fund-analysis.component.html',
  styleUrls: ['./fund-analysis.component.css']
})
export class FundAnalysisComponent implements OnInit {
  imgsrc = './assets/img/FundamentalAnalysis1.jpg';
  editda = './assets/img/photos/FundamentalAnalysis2.jpg';
  bvps = './assets/img/photos/BVPS.jpg';
  tfm = './assets/img/photos/ThreeFactorModel.jpg';
  matrics = './assets/img/photos/Matrix.jpg';
  marketValue = './assets/img/photos/MarketValueDefinition.jpg';
  EconomicMoat = './assets/img/photos/moat.jpg';
  cashflow = './assets/img/photos/cashflow.jpg';
  constructor() { }

  ngOnInit() {
  }
}
