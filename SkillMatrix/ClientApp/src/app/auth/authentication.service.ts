import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Moment } from 'moment';
import { shareReplay, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken } from './auth-user';

const baseUrl = 'api/authentication';
const baseUri = `${environment.apiEndpoint}/${baseUrl}`;

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const loginRoute = `${baseUri}/authenticate`;

    return this.http.post<IAuthToken>(loginRoute, { email, password }).pipe(
      tap({
        next: res => {
          this.setSession(res);
        }
      }),
      shareReplay(1)
    );

  }

  logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
  }

  isLoggedIn(): boolean {
    const expirationTime = this.getExpiration();
    return !!expirationTime ?? moment().isBefore(expirationTime);
  }

  isLoggedOut(): boolean {
    return !this.isLoggedIn();
  }

  private setSession(authResult: IAuthToken) {
    const expiresAt = moment().add(authResult.expiresIn, 'second');

    localStorage.setItem('id_token', authResult.accessToken);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
  }

  getExpiration(): Moment | null {
    const expiration = localStorage.getItem("expires_at");

    if (expiration !== null) {
      return moment(JSON.parse(expiration));
    }

    return null;
  }
}
