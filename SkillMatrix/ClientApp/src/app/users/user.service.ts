import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  headers = new HttpHeaders({ 'Content-type': 'application/json' });
  private userUrl = 'api/users';
  private baseUri = `${environment.apiEndpoint}/${this.userUrl}`;
  constructor(private http: HttpClient) { }

  getUsers(): Observable<IUser[]> {
    return this.http.get<IUser[]>(this.baseUri).pipe(catchError(this.handleError));
  }

  deleteUser(id: number): Observable<{}> {
    if (id === 0) {
      console.log("invalid user");
    }
    const url = `${this.userUrl}/${id}`;
    return this.http.delete<IUser>(url, { headers: this.headers });
  }

  createUser(user: IUser) {
    const url = `${this.userUrl}`;
    user.id = 0;
    return this.http.post<IUser>(url, user, { headers: this.headers });
  }

  updateUser(user: IUser): Observable<IUser> {
    const url = `${this.baseUri}/${user.id}}`;
    console.log(url);
    return this.http.put<IUser>(url, user, { headers: this.headers });
  }



  getUser(id: string): Observable<IUser> {
    if (id == "0") {
      return of(this.initializeUser());
    }

    const url = `${this.userUrl}/${id}`;
    return this.http.get<IUser>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  private initializeUser(): IUser {
    return {
      id: 0,
      surName: '',
      firstName: '',
      telephone: '',
      email: '',
      location: '',
      jobTitle: '',
      department: '',
      team: '',
      skills: [],
      languages: [],
      imageUrl: '',
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
