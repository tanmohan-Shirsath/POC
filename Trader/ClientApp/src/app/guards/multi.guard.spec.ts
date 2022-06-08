import { TestBed, async, inject } from '@angular/core/testing';

import { MultiGuard } from './multi.guard';

describe('MultiGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MultiGuard]
    });
  });

  it('should ...', inject([MultiGuard], (guard: MultiGuard) => {
    expect(guard).toBeTruthy();
  }));
});
