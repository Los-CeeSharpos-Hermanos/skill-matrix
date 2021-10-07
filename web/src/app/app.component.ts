import { Location } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private _location: Location) {

  }
  back = 'abc';
  backClicked(): void {
    if (this._location.path().includes("/skillmatrix/"))
      this._location.back();
  }

  title = 'Skill-Matrix by Andrei-Nicolae Ene, Conrado Goncalves, Marten Maiburg and Nico Wisotzki';
}

