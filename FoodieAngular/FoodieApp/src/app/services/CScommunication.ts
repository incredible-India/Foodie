import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable,catchError,map, of} from 'rxjs'
import { newUser } from '../models/newuser';
import {Injectable} from '@angular/core';

@Injectable({
    providedIn:'root'
})
export class Communication{
    constructor(private http: HttpClient){}

   private baseUrl = 'https://localhost:7000';
   private userService ='/api/user/service/';


   newUserRequest(body:newUser): Observable<any> {
    const url = this.baseUrl +this.userService + 'newuser';

    debugger;
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const requestbody = JSON.stringify(body)

    return this.http.put(url, requestbody, { headers }).pipe(
        map((response: any) => {
          // Handle successful response (2xx status codes)
          if (response.status >= 200 && response.status < 300) {
            // Process the response data here if needed
            return response.data;
          }
          // Handle other status codes
          else {
            // Throw an error or handle it accordingly
            throw new Error('Request failed with status code: ' + response.status);
          }
        }),
        catchError((error: any) => {
          // Handle any errors that occurred during the request
          // You can log the error, show a notification, or perform any other error handling
          console.error('Error in newUserRequest', error);
          return of(null); // Return an observable with a default value or null
        })
      );
    }


   }

    
