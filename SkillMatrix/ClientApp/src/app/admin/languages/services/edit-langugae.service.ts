import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditLangugaeService {

  private languageSource = new BehaviorSubject<number>(0);
  currentLanguage = this.languageSource.asObservable();

  constructor() { }

  changeLanguage(languageId: number) {
    this.languageSource.next(languageId);
  }
}
