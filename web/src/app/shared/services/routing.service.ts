import { Location } from '@angular/common';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoutingService {

  constructor(private router: Router, private _location: Location) { }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  goBack(): void {
    if (this._location.path().includes("/skillmatrix/"))
      this._location.back();
  }

}
