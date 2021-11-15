import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const idToken = localStorage.getItem("id_token");
    const userName = localStorage.getItem("user_name");
    console.log(userName);

    if (idToken) {
      const cloned = request.clone({
        headers: request.headers.set("Authorization",
          "Bearer " + idToken)
          .set("UserName", `${userName}`)
      });

      return next.handle(cloned);
    }
    else {
      return next.handle(request);
    }
  }
}
