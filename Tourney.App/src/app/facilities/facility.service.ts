import { Facility } from './facility.model';
import { PagedResponse } from '../company/company.model';
import { Observable } from 'rxjs/Rx';
import { AuthenticationService } from '../shared/authentication.service';
import { Http } from '@angular/http';
import { AuthenticatedServiceBase } from '../shared/authenticatedServiceBase';
import { Injectable } from '@angular/core';

@Injectable()
export class FacilityService extends AuthenticatedServiceBase {

  constructor(private http: Http, protected authenticationService: AuthenticationService) { 
    super(authenticationService);
   }

   getAll = () : Observable<PagedResponse<Facility>> => {
     if (!this.authenticationService.currentUser || !this.authenticationService.currentUser.access_token){
        return Observable.throw({message: "Not Authorized"});
     }

     return this.http
            .get('http://localhost:5001/api/facilities', this.createAuthorizationHeader(this.authenticationService.currentUser.access_token))
            .map(response => response.json());
   }

}
