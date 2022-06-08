import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EconomicDefComponent } from './economic-def.component';

describe('EconomicDefComponent', () => {
  let component: EconomicDefComponent;
  let fixture: ComponentFixture<EconomicDefComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EconomicDefComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EconomicDefComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
