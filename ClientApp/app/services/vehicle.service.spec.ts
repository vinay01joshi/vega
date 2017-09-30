import { TestBed, inject } from '@angular/core/testing';

import { VehicleService } from './make.service';

describe('MakeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehicleService]
    });
  });

  it('should be created', inject([VehicleService], (service: VehicleService) => {
    expect(service).toBeTruthy();
  }));
});
