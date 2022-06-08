import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EngulffingComponent } from './engulffing.component';

describe('EngulffingComponent', () => {
  let component: EngulffingComponent;
  let fixture: ComponentFixture<EngulffingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EngulffingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EngulffingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
