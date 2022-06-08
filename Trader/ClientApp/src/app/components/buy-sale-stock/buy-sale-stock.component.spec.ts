import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuySaleStockComponent } from './buy-sale-stock.component';

describe('BuySaleStockComponent', () => {
  let component: BuySaleStockComponent;
  let fixture: ComponentFixture<BuySaleStockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuySaleStockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuySaleStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
