import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { PerDay } from 'src/app/entities/perDay/per-day';
import { RentService } from 'src/app/entities/rentService/rent-service';
import { RentServiceDetailsService } from 'src/app/services/rentServices/rentServiceDetails/rent-service-details.service';
import * as CanvasJS from '../../../../../../../assets/canvasjs/canvasjs.min';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {
  rentService: RentService;
  chart: any;
	Month: number = new Date().getMonth() + 1;
	Year: number = new Date().getFullYear();
  Option: number = 0;
  id: number;

  constructor(private service: RentServiceDetailsService, public route: ActivatedRoute, public router: Router) { }
  
  ngOnInit(): void {

    this.route.params.subscribe(
      (params: Params) => {
        this.id = params['rentid'];
        this.service.getRentServiceById(this.id).subscribe(
          dataV => {
            this.rentService = dataV;
          }
        )
      }
    )

    this.route.params.subscribe(
      (params: Params) => {
        this.id = params['rentid'];});

		this.chart = new CanvasJS.Chart("chartContainer", {
			animationEnabled: true,
			exportEnabled: true,
			title: {
				text: "Chart of profit"
			},
			data: [{
				type: "column",
				dataPoints: []
			}]

		});
  }

  showMonth(){
    this.ShowForMonth();
  }

  showYear(){
    this.ShowForYear();
  }

  ShowForYear(){
    this.chart.options.data[0].dataPoints.length = 0;
    this.service.GetRevenuesForMonth(this.Year, this.id).subscribe((res: any) => {
      for (let index = 0; index < res.length; index++) {
        this.chart.options.data[0].dataPoints.push({  y: res[index].revenues , label: res[index].dayTime });
        this.chart.render();
      }
    });
  }
  
  ShowForMonth(){
    this.chart.options.data[0].dataPoints.length = 0;
    this.service.GetRevenuesForDay(this.Year, this.Month, this.id).subscribe((res: any) => {
      for (let index = 0; index < res.length; index++) {
        this.chart.options.data[0].dataPoints.push({ y: res[index].revenues , label: res[index].dayTime });
        this.chart.render();
      }
    });
  }


  onServiceRate(){
    this.router.navigateByUrl('/car/admin-info/' + this.rentService.serviceId + '/service-rate');
  }

  onCarRate(){
    this.router.navigateByUrl('/car/admin-info/' + this.rentService.serviceId + '/car-rate');
  }

  onGraph(){
    this.router.navigateByUrl('/car/admin-info/' + this.rentService.serviceId + '/graph');
    
  }

  onRevenues(){
    this.router.navigateByUrl('/car/admin-info/' + this.rentService.serviceId + '/revenues');
  }

}
