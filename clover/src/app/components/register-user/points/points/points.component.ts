import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PointsService } from 'src/app/services/points/points.service';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {

  PointsForm: FormGroup = new FormGroup({
    Points: new FormControl(''),
    Discount: new FormControl('')
  });

  constructor(private service: PointsService, public router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() : void{
    this.service.postPoints(this.PointsForm.get('Points').value, this.PointsForm.get('Discount').value).subscribe(
      res=>{
        this.router.navigateByUrl("/register-user");
      }
    )
  }

}
