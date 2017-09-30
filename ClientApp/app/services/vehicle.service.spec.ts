import { VehicleService } from './vehicle.service';
import { TestBed, inject } from '@angular/core/testing';

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
