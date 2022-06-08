import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketValueDefinitionComponent } from './market-value-definition.component';

describe('MarketValueDefinitionComponent', () => {
  let component: MarketValueDefinitionComponent;
  let fixture: ComponentFixture<MarketValueDefinitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarketValueDefinitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketValueDefinitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
