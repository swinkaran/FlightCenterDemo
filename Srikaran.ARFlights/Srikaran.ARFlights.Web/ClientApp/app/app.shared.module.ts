import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FlightsListComponent } from './components/flights-list/flights-list.component';
import { FlightSearchComponent } from './components/flight-search/flight-search.component';
import { BookingsListComponent } from './components/bookings/bookings.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FlightsListComponent,
        FlightSearchComponent,
        BookingsListComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'flights', component: FlightsListComponent },
            { path: 'flights/:id', component: FlightSearchComponent },
            { path: 'bookings', component: BookingsListComponent },            
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
