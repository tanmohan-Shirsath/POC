import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CashflowPatternComponent } from './cashflow-pattern.component';

describe('CashflowPatternComponent', () => {
  let component: CashflowPatternComponent;
  let fixture: ComponentFixture<CashflowPatternComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CashflowPatternComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CashflowPatternComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
