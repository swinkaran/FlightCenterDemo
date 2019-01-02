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
    public flight: Route;

    //Search variables
    public search_key: string = "";
    public search_text: string = "";

    constructor(private route: ActivatedRoute, http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseApiUrl = baseUrl;
        this.clientHttp = http;

        this.flightNo = this.route.snapshot.paramMap.get('id');

        this.clientHttp.get(this.baseApiUrl + 'api/flights/' + this.flightNo).subscribe(result => {
            this.flight = result.json() as Route;
        }, error => console.error(error));
    }
    
    onClickSearch() {
    
    }

    ngOnChanges(): void {
        //this.starWidth = this.movieId * 86 / 5;
    }

    public ngOnInit() {
        this.flightNo = this.route.snapshot.paramMap.get('id');
        this.clientHttp.get(this.baseApiUrl + 'api/flights/' + this.flightNo).subscribe(result => {
            this.flight = result.json() as Route;
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

