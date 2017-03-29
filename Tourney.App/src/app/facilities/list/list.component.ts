import { Facility } from '../facility.model';
import { PagedResponse } from '../../company/company.model';
import { Observable } from 'rxjs/Rx';
import { FacilityService } from '../facility.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  facilitiesAsynError: any;
  facilitiesAsync: Observable<PagedResponse<Facility>>;
  constructor(private facilityService: FacilityService) { }

  ngOnInit() {
    this.facilitiesAsync = this.facilityService.getAll();
    this.facilitiesAsync.subscribe(
      (data) => console.log("Facilities", data),
      (error) => this.facilitiesAsynError = error
    );
  }

}
