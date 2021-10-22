import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

const action = "Ok";

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(private _snackBar: MatSnackBar) { }

  duration: number = 5;

  success(message: string) {
    this._snackBar.open(message, action, {
      duration: durantionInSeconds(5),
      panelClass: ['mat-toolbar', 'mat-primary']
    });
  }

  warn(message: string) {
    this._snackBar.open(message, action, {
      duration: durantionInSeconds(5),
      panelClass: ['mat-toolbar', 'mat-warn']
    });
  }
}

function durantionInSeconds(duration: number): number {
  return duration * 1000;
}

