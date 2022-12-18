import { TestBed } from '@angular/core/testing';

import { DisciplineApiService } from './discipline.api.service';

describe('DisciplineApiService', () => {
  let service: DisciplineApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DisciplineApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
