import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatistechComponent } from './whatistech.component';

describe('WhatistechComponent', () => {
  let component: WhatistechComponent;
  let fixture: ComponentFixture<WhatistechComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhatistechComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhatistechComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
