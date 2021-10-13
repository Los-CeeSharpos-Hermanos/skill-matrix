import { Component, OnInit } from '@angular/core';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { EditLangugaeService } from './edit-langugae.service';


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
  languageToEdit: string;
  pageTitle: string;
  language: ILanguage = {code: "code", name: "name", nativeName: "nativeName"};

  constructor(private router: Router, private languageService: LanguageService, private data: EditLangugaeService) { }

  clickAdd(name: string, nativeName: string, code: string, type: string): void {
    //prototype method
    if(type == "default") {
      this.isThere = false;
      for(let language of this.languages) {
        if(language.name == name || language.nativeName == nativeName || language.code == code) {
          this.isThere = true; break;
        }
      }
      if(!this.isThere) {
        if(name!="" && nativeName!="" && code!="") {
          this.languages.push({name, nativeName, code});
          alert('New Language added');
        } else {
          alert('Please fill every field')
        }
      } else {
        alert('Some Properties of your language already exist!');
      }
  
      //test output -- can be removed later
      for(let language of this.languages) {
        console.log(language.name);
      }
      //get notification from server
      //if saved show confirmation message
      //if existing show error
    } else {
      for(let language of this.languages) {
        if(language.name == this.languageToEdit) {
          if(name!="" && nativeName!="" && code!="") {
            language.name = name;
            language.nativeName = nativeName;
            language.code = code;
            alert('Language changed');
          } else {
            alert('Please fill every field')
          }
    
        }
      }
      //test output -- can be removed later
      for(let language of this.languages) {
        console.log(language.name);
      }
    }
  } 

  ngOnInit(): void {
    this.data.currentLanguage.subscribe(language => this.languageToEdit = language);
    this.sub = this.languageService.getLanguages().subscribe({
      next: languages => {
        this.languages = languages;
        console.log(this.languages);
        if(this.languageToEdit == "default") {
          this.pageTitle = "Add a new Langugae";
          console.log(this.languages)
        } else {
          this.pageTitle = "Edit the Language " + this.languageToEdit;
          for(let language of this.languages) {
            if(language.name == this.languageToEdit) {
              this.language.name = language.name;
              this.language.nativeName = language.nativeName;
              this.language.code = language.code;
            }
          }
        }
      },
      error: err => this.errorMessage = err
    });
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }
}
