import { Component, Inject } from "@angular/core";
import { Http } from '@angular/http';

@Component({
    selector: 'bookings',
    templateUrl: './bookings.component.html',
    styleUrls: ['./bookings.component.css']
})

export class BookingsListComponent {
    public bookings: Booking[] = [];
    public resultsCount: number = 0;

    private baseApiUrl: string = "";
    private api_Url: string = "";

    private clientHttp: Http;

    //Search variables
    public search_key: string = "";
    public search_text: string = "none";
    public search_by: string = "";

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseApiUrl = baseUrl;
        this.clientHttp = http;

        this.clientHttp.get(this.baseApiUrl + 'api/bookings').subscribe(result => {
            this.bookings = result.json() as Booking[];
            this.resultsCount = this.bookings.length;
        }, error => console.error(error));
    }

    onClickSearch() {

        
        switch (this.search_key) {
            case "1": {
                this.search_by = "Flight no";
                this.api_Url = "api/bookings/flight/";
                break;
            }
            case "2": {
                this.search_by = "Passenger name";
                this.api_Url = "api/bookings/passenger/";
                break;
            }
            case "3": {
                this.search_by = "Booking date";
                break;
            }
            case "4": {
                this.search_by = "Departure city";
                this.api_Url = "api/bookings/cities/departure/";
                break;
            }
            case "5": {
                this.search_by = "Arrival city";
                this.api_Url = "api/bookings/cities/arrival/";
                break;
            }
            default: {
                this.search_by = "none";
                this.api_Url = "api/bookings/";
                break;
            }
        } 

        this.clientHttp.get(this.baseApiUrl + this.api_Url + this.search_text).subscribe(result => {
            this.bookings = result.json() as Booking[];
            this.resultsCount = this.bookings.length;
        }, error => console.error(error));
    }
}

interface Booking {
    bookingId: number;
    bookingDate: string;
    flightNo: string;
    passengerName: string;
    startTime: string;
    endTime: string;
    departureCity: string;
    arrivalCity: string;
}
