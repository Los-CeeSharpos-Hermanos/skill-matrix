import { Component, OnInit } from '@angular/core';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-language',
  templateUrl: './add-language.component.html',
  styleUrls: ['./add-language.component.scss']
})

export class AddLanguageComponent implements OnInit {
  errorMessage: string = '';
  sub!: Subscription;
  languages: ILanguage[] = [];
  isThere: Boolean = false;
  constructor(private router: Router, private languageService: LanguageService) { }

  clickAdd(name: string, nativeName: string, code: string): void {
    //prototype method
    this.isThere = false;
    for(let language of this.languages) {
      if(language.name == name || language.nativeName == nativeName || language.code == code) {
        this.isThere = true; break;
      }
    }
    if(!this.isThere) {
      if(name!="" && nativeName!="" && code!="") {
        this.languages.push({name, nativeName, code});
      }
    }
    for(let language of this.languages) {
      console.log(language.name);
    }
    //get notification from server
    //if saved show confirmation message
    //if existing show error
  }

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
