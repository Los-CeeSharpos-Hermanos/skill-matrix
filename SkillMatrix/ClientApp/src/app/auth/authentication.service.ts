import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Moment } from 'moment';
import { BehaviorSubject } from 'rxjs';
import { shareReplay, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken, IRegisterUser } from './auth-user';

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
          this.isLoggedIn();
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

  registerNewUser({ email, password, passwordConfirmation, firstName, surName }: IRegisterUser) {
    const newAccountRoute = `${baseUri}/new-account`;

    return this.http.post<IAuthToken>(newAccountRoute, { email, password, passwordConfirmation, firstName, surName }).pipe(
      tap({
        next: res => {
          this.setSession(res);
          this.isLoggedUser.next(this.isLoggedIn());
        }
      }),
      shareReplay(1)
    );
  }

  isLoggedIn(): boolean {
    const expirationTime = this.getExpiration();
    const isNotTokenExpired = expirationTime == null ? false : moment().isBefore(expirationTime);
    const token = localStorage.getItem('id_token');
    const userName = localStorage.getItem("user_name");
    const isLoggedIn = userName && token && isNotTokenExpired ? true : false;

    this.isLoggedUser.next(isLoggedIn);

    return isLoggedIn;
  }

  isLoggedOut(): boolean {
    return !this.isLoggedIn();
  }

  private setSession(authResult: IAuthToken) {
    const expiresAt = moment().add(authResult.expiresIn, 'second');
    localStorage.setItem('id_token', authResult.accessToken);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
    localStorage.setItem("user_id", authResult.userInfo.id);
    localStorage.setItem("user_name", authResult.userInfo.email);
  }

  getExpiration(): Moment | null {
    const expiration = localStorage.getItem("expires_at");

    if (expiration !== null) {
      return moment(JSON.parse(expiration));
    }

    return null;
  }

  getLoggedUser() {
    return localStorage.getItem("user_id");
  }

}
