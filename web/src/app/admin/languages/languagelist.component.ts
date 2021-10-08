import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILanguage } from './language';
import { LanguageService } from './language.service';

@Component({
  selector: 'app-languagelist',
  templateUrl: './languagelist.component.html',
  styleUrls: ['./languagelist.component.scss']
})
export class LanguagelistComponent implements OnInit {
  
  errorMessage: string = '';
  sub!: Subscription;
  languages: ILanguage[] = [];

  /*
  languages: string[] = [
    "german", "english", "spanish", "french" 
  ]; //get list of languages from database here
*/
  constructor(private router: Router, private languageService: LanguageService) { }

  ngOnInit(): void {
    this.sub = this.languageService.getLanguages().subscribe({
      next: languages => {
        this.languages = languages;
      },
      error: err => this.errorMessage = err
    });
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }

}