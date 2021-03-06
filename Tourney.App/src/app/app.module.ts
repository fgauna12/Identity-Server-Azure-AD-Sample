import { FacilityService } from './facilities/facility.service';
import 'bootstrap';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AuthorizationService } from './shared/authorization.service';
import { CompanyService } from './company/company.service';
import { AuthenticationService } from './shared/authentication.service';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { AuthenticatedServiceBase } from './shared/authenticatedServiceBase';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './routing/notfound/notfound.component';
import { RoutingModule } from './routing/routing.module';
import { NewTournamentComponent } from './new-tournament/new-tournament.component';
import { CallbackComponent } from './login/callback/callback.component';
import { ListComponent } from './facilities/list/list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardComponent,
    NotfoundComponent,
    NewTournamentComponent,
    CallbackComponent,
    ListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RoutingModule,
    NgbModule.forRoot(),
  ],
  providers: [AuthenticationService, CompanyService, AuthorizationService, FacilityService],
  bootstrap: [AppComponent]
})
export class AppModule { }
