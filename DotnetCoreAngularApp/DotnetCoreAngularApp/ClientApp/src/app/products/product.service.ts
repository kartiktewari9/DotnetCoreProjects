import { IProduct } from './product';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError,tap, map } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn:'root'
})
 export class ProductService {

  private allProductUrl='api/product'; 
  private productByIdUrl = 'api/product/'; 
  
  constructor(private httpClient:HttpClient) {
    
  }

  getProducts():Observable<IProduct[]> {
    return this.httpClient.get<IProduct[]>(this.allProductUrl).pipe(
      tap(data=> console.log('All : '+JSON.stringify(data))),
      catchError(this.handleError)
    );
    }

    getProduct(id: number): Observable<IProduct | undefined> {
      return this.httpClient.get<IProduct>(this.productByIdUrl+id).pipe(
        tap(data => console.log('By Id : ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
    }

    private handleError(err: HttpErrorResponse) {
      // in a real world app, we may send the server to some remote logging infrastructure
      // instead of just logging it to the console
      let errorMessage = '';
      if (err.error instanceof ErrorEvent) {
        // A client-side or network error occurred. Handle it accordingly.
        errorMessage = `An error occurred: ${err.error.message}`;
      } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong,
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
      }
      console.error(errorMessage);
      return throwError(errorMessage);
    }
 }
