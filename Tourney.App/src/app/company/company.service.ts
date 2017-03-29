import { AuthenticatedServiceBase } from '../shared/authenticatedServiceBase';
import { AuthenticationService } from '../shared/authentication.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Company, PagedResponse } from './company.model';

@Injectable()
export class CompanyService {
  constructor(private http: Http) {
  }

  getCompanies = (): Observable<PagedResponse<Company>> => {
    return this.http
      .get('http://localhost:5001/api/companies')
      .map(response => response.json());
  }
}


