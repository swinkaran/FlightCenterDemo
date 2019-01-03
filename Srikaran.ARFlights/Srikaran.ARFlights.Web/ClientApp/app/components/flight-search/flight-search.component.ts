import { Component, OnChanges, Input, Output, EventEmitter, OnInit, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Http } from "@angular/http";

@Component({
    selector: 'flight-search',
    templateUrl: './flight-search.component.html',
    styleUrls: ['./flight-search.component.css']
})

export class FlightSearchComponent implements OnChanges, OnInit {
    public flightNo: string = "";
    private baseApiUrl: string = "";
    private clientHttp: Http;
    public flight_route: Route;

    //Search variables
    public search_noOxPax: string = "";
    public search_date_from: string = "";
    public search_date_to: string = "";
    public flights: Flight[];
    public search_numberOfPax: string = "";

    constructor(private route: ActivatedRoute, http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseApiUrl = baseUrl;
        this.clientHttp = http;

        this.flightNo = this.route.snapshot.paramMap.get('id');

        this.clientHttp.get(this.baseApiUrl + 'api/flights/' + this.flightNo).subscribe(result => {
            this.flight_route = result.json() as Route;
        }, error => console.error(error));
    }

    onClickSearch() {
        this.search_numberOfPax = this.search_noOxPax;
        this.clientHttp.get(this.baseApiUrl + 'api/flights/' + this.flightNo + '/' + this.search_date_from + '/' + this.search_date_to).subscribe(result => {
            this.flights = result.json() as Flight[];
        }, error => console.error(error));
    }

    ngOnChanges(): void {
    }

    public ngOnInit() {
        this.flightNo = this.route.snapshot.paramMap.get('id');
        this.clientHttp.get(this.baseApiUrl + 'api/flights/' + this.flightNo).subscribe(result => {
            this.flight_route = result.json() as Route;
        }, error => console.error(error));
    }
}

interface Route {
    flightNo: string;
    startTime: string;
    endTime: string;
    departureCity: string;
    arrivalCity: string;
    passengerCapacity: number;
}

interface Flight {
    flightNo: string;
    dateToFly: Date;
    seatsLeft: number;
    passengerCapacity: number;
}

