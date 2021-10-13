import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditLangugaeService {

  private languageSource = new BehaviorSubject<string>("default language");
  currentLanguage = this.languageSource.asObservable();

  constructor() { }

  changeLanguage(language: string) {
    this.languageSource.next(language);
  }
}
