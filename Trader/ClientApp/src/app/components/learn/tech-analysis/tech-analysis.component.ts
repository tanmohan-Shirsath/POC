import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tech-analysis',
  templateUrl: './tech-analysis.component.html',
  styleUrls: ['./tech-analysis.component.css']
})
export class TechAnalysisComponent implements OnInit {
  techdef = './assets/img/photos/Technical Analysis/img2.jpg';
  img1 = './assets/img/photos/Technical Analysis/img1.jpg';
  candleflow = './assets/img/photos/Technical Analysis/candlestick.jpg';
  areaOfVal = './assets/img/photos/Technical Analysis/areaOfValue.jpg';
  trigger = './assets/img/photos/Technical Analysis/Trigger.jpg';
  fivething = './assets/img/photos/Technical Analysis/img4.jpg';
  Bulish = './assets/img/photos/Technical Analysis/Engulish.jpg';
  chartpattern = './assets/img/photos/Technical Analysis/ChartPattern.jpg';
  constructor() { }

  ngOnInit() {
  }

}
