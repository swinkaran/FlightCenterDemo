import { Component, Inject } from "@angular/core";
import { Http } from '@angular/http';

@Component({
    selector: 'flights-list',
    templateUrl: './flights-list.component.html',
    styleUrls: ['./flights-list.component.css']
})

export class FlightsListComponent {
    public flights: Flight[] = [];
    public flightsCount: number = 7;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        this.flightsCount = 6;

        http.get(baseUrl + 'api/flights').subscribe(result => {
            this.flights = result.json() as Flight[];
        }, error => console.error(error));

        //this.flightsCount = this.flights.length;
    }
}

interface Flight {
    flightNo: string;
    startTime: string;
    endTime: string;
    departureCity: string;
    arrivalCity: string;
    passengerCapacity: number;
}
