import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ILanguage } from '../language';

@Injectable({
  providedIn: 'root'
})

export class LanguageService {

  headers = new HttpHeaders({ 'Content-type': 'application/json' });
  private languageUrl = 'api/languages';

  constructor(private http: HttpClient) { }

  getLanguages(): Observable<ILanguage[]> {
    return this.http.get<ILanguage[]>(`${environment.apiEndpoint}/${this.languageUrl}`);
  }

  deleteLanguage(id: number): Observable<{}> {
    if (id === 0) {
      console.log("invalid language");
    }
    const url = `${this.languageUrl}/${id}`;
    return this.http.delete<ILanguage>(url, { headers: this.headers });
  }

  createLanguage(language: ILanguage) {
    const url = `${environment.apiEndpoint}/${this.languageUrl}`;
    return this.http.post<ILanguage>(url, language, { headers: this.headers });
  }

  updateLanguage(language: ILanguage): Observable<ILanguage> {
    const url = `${environment.apiEndpoint}/${this.languageUrl}/${language.id}`;
    return this.http.put<ILanguage>(url, language, { headers: this.headers });
  }

  getLanguage(id: string): Observable<ILanguage> {
    if (id == "0") {
      return of(this.initializeLanguage());
    }

    const url = `${environment.apiEndpoint}/${this.languageUrl}/${id}`;
    return this.http.get<ILanguage>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  private initializeLanguage(): ILanguage {
    return {
      id: 0,
      code: null,
      name: null,
      nativeName: null
    };
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
