import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreefactModelComponent } from './threefact-model.component';

describe('ThreefactModelComponent', () => {
  let component: ThreefactModelComponent;
  let fixture: ComponentFixture<ThreefactModelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThreefactModelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThreefactModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
