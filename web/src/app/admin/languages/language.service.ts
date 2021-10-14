import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ILanguage } from './language';

@Injectable({
  providedIn: 'root'
})

export class LanguageService {

  headers = new HttpHeaders({ 'Content-type': 'application/json' });
  private languageUrl = 'api/languages';

  constructor(private http: HttpClient) { }

  getLanguages(): Observable<ILanguage[]> {
    return this.http.get<ILanguage[]>(this.languageUrl).pipe(tap(data => console.log('All')), catchError(this.handleError));
  }

  deleteLanguage(id: number): Observable<{}> {
    if (id === 0) {
      console.log("invalid language");
    }
    const url = `${this.languageUrl}/${id}`;
    return this.http.delete<ILanguage>(url, { headers: this.headers });
  }

  createLanguage(language: ILanguage) {
    const url = `${this.languageUrl}/${language.id}}`;
    return this.http.post<ILanguage>(url, language, { headers: this.headers });
  }

  updateLanguage(language: ILanguage): Observable<ILanguage> {
    const url = `${this.languageUrl}/${language.id}}`;
    return this.http.put<ILanguage>(url, language, { headers: this.headers });
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occured. Handle it accordingly.
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
