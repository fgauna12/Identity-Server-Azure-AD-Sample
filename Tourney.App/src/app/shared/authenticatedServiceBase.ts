import { Observable } from 'rxjs/Rx';
import { AuthenticationService } from './authentication.service';
import { RequestOptionsArgs } from '@angular/http/src/interfaces';
import { Headers, Http, Response } from '@angular/http';

export class AuthenticatedServiceBase {
    constructor(protected authenticationService: AuthenticationService) {
    }

    private getAuthTokenPromise = (): Promise<string> => {
        return this.authenticationService.getUser().then((user) => {
            return user.access_token;
        });
    }

    private getRequestOptions = (headers: Headers): RequestOptionsArgs => {
        return {
            headers: headers
        };
    }

    protected createAuthorizationHeader(accessToken: string): RequestOptionsArgs {
        const headers = new Headers();
        headers.append('Authorization', `Bearer ${accessToken}`);
        const requestOptions: RequestOptionsArgs = {
            headers: headers
        };
        return requestOptions;
    }
}