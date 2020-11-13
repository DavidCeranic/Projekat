import { Injectable, EventEmitter, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { HttpClient } from '@angular/common/http';
import { RentService } from 'src/app/entities/rentService/rent-service';
import { PerDay } from 'src/app/entities/perDay/per-day';

@Injectable({
  providedIn: 'root'
})
export class RentServiceDetailsService {

  private messageSource = new BehaviorSubject<RentService>(null);
  currentMessage = this.messageSource.asObservable();

  @Output() messageEvent = new EventEmitter<RentService[]>();

  formData: RentService;
  readonly rootUrl= 'http://localhost:5002/api/';
  list: RentService[];
  selectedService: RentService;

  constructor(private http:HttpClient) { }

  changeMessage(message: RentService){
    this.messageSource.next(message);
  }
  
  postRentService(formData: RentService){
    return this.http.post(this.rootUrl + 'RentServices', formData);
  }

  refreshList(){
    this.http.get(this.rootUrl + 'RentServices').toPromise().then(res => {
      this.list = res as RentService[];
      this.messageEvent.emit(this.list);
    } );
  }

  refreshList2() : Promise<RentService[]>{
    return this.http.get<RentService[]>(this.rootUrl + 'RentServices').toPromise();
  }

  putRentService(formData: RentService, serviceId: string){
    var num = parseInt(serviceId);
    formData.serviceId = serviceId;
    return this.http.put(this.rootUrl + 'RentServices/'+num, formData);
  }

  deleteRentService(serviceId: number){
    return this.http.delete(this.rootUrl + 'RentServices/'+serviceId);
  }

  getRentServiceById(serviceId: number){
    return this.http.get<RentService>(this.rootUrl + 'RentServices/' + serviceId.toString());
  }

  GetRevenuesForMonth(year: number, serviceId:number){
    return this.http.get<PerDay[]>(this.rootUrl + 'RentServices/GetRevenuesForMonth/' + year+'/'+serviceId);
  }

  GetRevenuesForDay(year: number, month: number, serviceId:number){
    return this.http.get<PerDay[]>(this.rootUrl + 'RentServices/GetRevenuesForDay/' + year+'/'+month+'/'+serviceId);
  }

}
