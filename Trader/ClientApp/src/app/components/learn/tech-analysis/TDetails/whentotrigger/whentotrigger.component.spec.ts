import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhentotriggerComponent } from './whentotrigger.component';

describe('WhentotriggerComponent', () => {
  let component: WhentotriggerComponent;
  let fixture: ComponentFixture<WhentotriggerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhentotriggerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhentotriggerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
