import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Moment } from 'moment';
import { BehaviorSubject } from 'rxjs';
import { shareReplay, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken } from './auth-user';

const baseUrl = 'api/authentication';
const baseUri = `${environment.apiEndpoint}/${baseUrl}`;

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public isLoggedUser = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const loginRoute = `${baseUri}/authenticate`;

    return this.http.post<IAuthToken>(loginRoute, { email, password }).pipe(
      tap({
        next: res => {
          this.setSession(res);
          this.isLoggedUser.next(this.isLoggedIn());
        }
      }),
      shareReplay(1)
    );

  }

  logout() {

    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
    localStorage.removeItem("user_id");

    this.isLoggedUser.next(this.isLoggedIn());

  }

  isLoggedIn(): boolean {
    const expirationTime = this.getExpiration();
    const isTokenExpired = expirationTime == null ? false : moment().isBefore(expirationTime);
    const token = localStorage.getItem('id_token');
    return !!token && isTokenExpired;
  }

  isLoggedOut(): boolean {
    return !this.isLoggedIn();
  }

  private setSession(authResult: IAuthToken) {
    const expiresAt = moment().add(authResult.expiresIn, 'second');
    console.log(authResult);

    localStorage.setItem('id_token', authResult.accessToken);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
    localStorage.setItem("user_id", authResult.userInfo.id);
  }

  getExpiration(): Moment | null {
    const expiration = localStorage.getItem("expires_at");

    if (expiration !== null) {
      return moment(JSON.parse(expiration));
    }

    return null;
  }
}
