import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BVCSComponent } from './bvcs.component';

describe('BVCSComponent', () => {
  let component: BVCSComponent;
  let fixture: ComponentFixture<BVCSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BVCSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BVCSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
