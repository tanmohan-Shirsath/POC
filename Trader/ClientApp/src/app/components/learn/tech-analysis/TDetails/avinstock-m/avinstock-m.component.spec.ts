import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AVinstockMComponent } from './avinstock-m.component';

describe('AVinstockMComponent', () => {
  let component: AVinstockMComponent;
  let fixture: ComponentFixture<AVinstockMComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AVinstockMComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AVinstockMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
