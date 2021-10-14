import { Component, OnInit } from '@angular/core';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { EditLangugaeService } from './edit-langugae.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';


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
  languageToEdit: number;
  pageTitle: string;
  
  language: ILanguage = {id: 0, code: "code", name: "name", nativeName: "nativeName"};

  constructor(private router: Router, private languageService: LanguageService, private data: EditLangugaeService, private snackBarService: SnackBarService) { }

  clickAdd(id: number, name: string, nativeName: string, code: string, type: number): void {
    this.language = {id: (id+1), code: code, name: name, nativeName: nativeName}
    //add
    this.isThere = false;
    for(let language of this.languages) {
      if(language.name == name || language.nativeName == nativeName || language.code == code) {
        this.isThere = true; break;
      }
    }
    if(!this.isThere) {
      if(type == 0) {
        if(this.language.name!="" && this.language.nativeName!="" && this.language.code!="") {
          this.languageService.createLanguage(this.language)
          .subscribe({
          next: () => this.onSaveComplete(),
          error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });
        } else {
          this.snackBarService.warn('Please fill every field');
        }
    //edit
      } else {
        for(let language of this.languages) {
          if(language.id == this.languageToEdit) {
            if(name!="" && nativeName!="" && code!="") {
              language= {id: language.id, name: name, nativeName: nativeName, code: code};
              this.languageService.updateLanguage(language)
              .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
              });
            } else {
              this.snackBarService.warn('Please fill every field');
              }
          }
        }
      }
    } else {this.snackBarService.warn('Some Properties of your language already exist!')}
  } 

  ngOnInit(): void {
    this.data.currentLanguage.subscribe(language => this.languageToEdit = language);
    this.sub = this.languageService.getLanguages().subscribe({
      next: languages => {
        this.languages = languages;
        if(this.languageToEdit == 0) {
          this.pageTitle = "Add a new Langugae";
        } else {
          for(let language of this.languages) {
            if(language.id == this.languageToEdit) {
              this.language.name = language.name;
              this.language.nativeName = language.nativeName;
              this.language.code = language.code;
            }
          }
          this.pageTitle = "Edit the Language " + this.language.name;
        }
      },
      error: err => this.errorMessage = err
    });
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  onSaveComplete(message: string = "Language saved successfully!") {
    this.snackBarService.success(message);
    this.goTo('/skillmatrix/languages');
  }
}
