import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { AuthenticationService } from './authentication.service';
import { AuthenticatedServiceBase } from './authenticatedServiceBase';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthorizationService extends AuthenticatedServiceBase {

  constructor(private http: Http, protected authenticationService: AuthenticationService) {
    super(authenticationService);
  }
}
