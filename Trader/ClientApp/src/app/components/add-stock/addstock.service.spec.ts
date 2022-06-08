import { TestBed } from '@angular/core/testing';

import { AddstockService } from './addstock.service';

describe('AddstockService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AddstockService = TestBed.get(AddstockService);
    expect(service).toBeTruthy();
  });
});
