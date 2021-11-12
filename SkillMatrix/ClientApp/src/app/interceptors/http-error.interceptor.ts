import {
  HttpErrorResponse,
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../auth/authentication.service';
import { SnackBarService } from '../shared/services/snack-bar.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private snackBarService: SnackBarService, private authService: AuthenticationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMsg = '';
          if (error.error instanceof ErrorEvent) {
            errorMsg = `Error: ${error.error.message}`;
          }
          else {
            errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
          }
          console.log(JSON.stringify(error));
          this.snackBarService.warn("An error has occured during your request. Try again!");
          this.authService.isLoggedIn();
          return throwError(errorMsg);
        })
      );
  }
}
