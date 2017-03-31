import { AuthenticatedServiceBase } from './authenticatedServiceBase';
import { Observable } from 'rxjs/Rx';
import { Injectable, EventEmitter } from '@angular/core';
import { UserManager, Log, User } from 'oidc-client';

export const UserManagerConfiguration: Oidc.UserManagerSettings = {
  authority: "http://localhost:5000",
  client_id: "js",
  redirect_uri: "http://localhost:5003/callback",
  response_type: "id_token token",
  scope: "openid profile dealerApi custom.profile",
  post_logout_redirect_uri: "http://localhost:5003/index.html"
  //loadUserInfo: true
};

@Injectable()
export class AuthenticationService {
  mgr: UserManager;
  userLoadedEvent: EventEmitter<User> = new EventEmitter<User>();
  currentUser: User;
  constructor() {
    this.mgr = new UserManager(UserManagerConfiguration);
    Log.logger = console;
  }

  getUser(): Promise<User> {
    return this.mgr.getUser().then((user) => { 
      this.currentUser = user;
      this.userLoadedEvent.emit(user);
      return user;
    });
  }

  isLoggedIn(): Observable<boolean> {
    return Observable.fromPromise(this.getUser()).map(user => user ? true : false);
  }

  login = () => {
    this.mgr.signinRedirect();
  }

  logout = () => {
    this.mgr.signoutRedirect();
  }
}
