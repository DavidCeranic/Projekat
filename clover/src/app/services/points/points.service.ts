import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PointsService {

  readonly rootUrl= 'http://localhost:5002/api/';

  constructor(private http:HttpClient) { }

  postPoints(Points: number, Discount: number){
    return this.http.get(this.rootUrl + 'ConfigurationPrice/ChangePoints/'+Points+'/'+Discount);
  }

  checkDiscount(){
    return this.http.get(this.rootUrl + 'ConfigurationPrice/GetDiscount/'+localStorage.getItem('regId'));
  }
}
