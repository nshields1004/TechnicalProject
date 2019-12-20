import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Players } from '../models/players';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/Players/';
  }

  getPlayers(): Observable<Players[]> {
    return this.http.get<Players[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getPlayer(id: number): Observable<Players> {
      return this.http.get<Players>(this.myAppUrl + this.myApiUrl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  savePlayer(players): Observable<Players> {
      return this.http.post<Players>(this.myAppUrl + this.myApiUrl, JSON.stringify(players), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updatePlayer(id: number, players): Observable<Players> {
      return this.http.put<Players>(this.myAppUrl + this.myApiUrl + players, JSON.stringify(players), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deletePlayers(id: number): Observable<Players> {
      return this.http.delete<Players>(this.myAppUrl + this.myApiUrl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}