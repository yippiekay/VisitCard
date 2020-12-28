import { TestBed } from '@angular/core/testing';

import { VisitCardService } from './visit-card.service';

describe('VisitCardService', () => {
  let service: VisitCardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VisitCardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
