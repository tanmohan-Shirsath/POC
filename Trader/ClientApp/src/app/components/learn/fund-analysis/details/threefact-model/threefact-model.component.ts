import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-threefact-model',
  templateUrl: './threefact-model.component.html',
  styleUrls: ['./threefact-model.component.css']
})
export class ThreefactModelComponent implements OnInit {

  threefact = './assets/ProjectImg/Capture.MHT';
  constructor() { }

  ngOnInit() {
  }

}
