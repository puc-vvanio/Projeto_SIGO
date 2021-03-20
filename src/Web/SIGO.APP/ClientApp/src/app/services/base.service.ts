import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class BaseService {

    /**
     * API url
     */
    private readonly API: string;

    /**
     * Creates an instance of BaseService.
     */
    constructor(private http: HttpClient) {
        this.API = environment.API;
    }

    /**
     * Call to a GET endpoint.
     */
    public get(endPoint: string) {
        // creating request header
        var options = this.createRequestOptions();
        // sending request to api server
        return this.http.get(this.API + endPoint, options);
    }

    /**
     * Call to a POST endpoint.
     */
    public post(endPoint: string, data: any) {
        // creating request header
        let options = this.createRequestOptions();
        // adding data to request boby
        let body = JSON.stringify(data);
        // sending request to api server
        return this.http.post<any>(this.API + endPoint, body, options);
    }

    /**
     * Request builder to add Auth param
     */
    public createRequestOptions(params?: HttpParams) {
        // retrieve token from local storage
        let token = localStorage.getItem('TOKEN');
        // adding token Bearer to header
        let options =
        {
            headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${token}`),
            params: params
        }

        return options;
    }
}