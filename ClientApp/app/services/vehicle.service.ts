import { SaveVehicle } from './../models/vehicle';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  private readonly vihicleEndPoint = '/api/vehicles';
  constructor(private http: Http) { }

  getMakes() {
    return this.http.get('/api/makes')
        .map(res => res.json());
  }

  getFeatures() {
    return this.http.get('/api/features')
      .map(res => res.json());
  }

  create(vehicle: any) {    
    return this.http.post('/api/vehicles', vehicle)
      .map(res => res.json());
  }

  getVehicle(id: any) {
    return this.http.get(this.vihicleEndPoint + '/' +id)
      .map(res => res.json());
  }

  getVehicles(filter: any) {
    return this.http.get(this.vihicleEndPoint + '?' + this.toQueryString(filter))
      .map(res => res.json())
  }

  toQueryString(obj: any) {
    var parts = [];
    for(var property in obj) {
      var value = obj[property];
      if(value != null && value != undefined)
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));        
    }
    return parts.join('&');
  }

  update(vehicle: SaveVehicle) {    
    return this.http.put(this.vihicleEndPoint + '/' + vehicle.id, vehicle)
      .map(res => res.json());
  }

  delete(id: number) {
    return this.http.delete('/api/vehicles/' +id)
      .map(res => res.json());
  }

}
