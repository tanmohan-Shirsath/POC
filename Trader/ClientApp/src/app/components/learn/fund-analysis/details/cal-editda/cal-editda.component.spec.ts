import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalEDITDAComponent } from './cal-editda.component';

describe('CalEDITDAComponent', () => {
  let component: CalEDITDAComponent;
  let fixture: ComponentFixture<CalEDITDAComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalEDITDAComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalEDITDAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
