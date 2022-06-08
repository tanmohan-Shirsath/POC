import { TestBed } from '@angular/core/testing';

import { NyseService } from './nyse.service';

describe('NyseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NyseService = TestBed.get(NyseService);
    expect(service).toBeTruthy();
  });
});
