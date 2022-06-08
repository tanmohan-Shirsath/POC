import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NyseComponent } from './nyse.component';

describe('NyseComponent', () => {
  let component: NyseComponent;
  let fixture: ComponentFixture<NyseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NyseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NyseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
