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
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const requestbody = JSON.stringify(body)

    return this.http.put(url, requestbody, { headers })
    }


   }

    
