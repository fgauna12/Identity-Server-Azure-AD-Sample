import { PagedResponse } from '../company/company.model';
import { Observable } from 'rxjs/Rx';
import { Company } from '../company/company.model';
import { CompanyService } from '../company/company.service';
import { AuthenticationService } from '../shared/authentication.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  companiesAsync: Observable<PagedResponse<Company>>;
  isLoggedIn: boolean;
  constructor(private authenticationService: AuthenticationService,
              private companyService: CompanyService) {}

  ngOnInit() {
    this.loadCompanies();
    this.authenticationService.isLoggedIn()
      .subscribe(isLoggedIn => { this.isLoggedIn = isLoggedIn; });
  }

  loadCompanies() {
    this.companiesAsync = this.companyService.getCompanies();
  }
}
