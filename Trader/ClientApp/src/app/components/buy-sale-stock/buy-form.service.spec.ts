import { TestBed } from '@angular/core/testing';

import { BuyFormService } from './buy-form.service';

describe('BuyFormService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BuyFormService = TestBed.get(BuyFormService);
    expect(service).toBeTruthy();
  });
});
