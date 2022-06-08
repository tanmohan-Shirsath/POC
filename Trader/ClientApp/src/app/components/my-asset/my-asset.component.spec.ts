import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAssetComponent } from './my-asset.component';

describe('MyAssetComponent', () => {
  let component: MyAssetComponent;
  let fixture: ComponentFixture<MyAssetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyAssetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAssetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
