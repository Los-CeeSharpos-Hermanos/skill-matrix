import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-languagelist',
  templateUrl: './languagelist.component.html',
  styleUrls: ['./languagelist.component.scss']
})
export class LanguagelistComponent implements OnInit {
  
  errorMessage: string = '';
  sub!: Subscription;
  languages: ILanguage[] = [];
  filteredLanguages: ILanguage[] = [];

  public pageSlice: ILanguage[] = [];

  //filter
  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value:string) {
    this._listFilter = value;
    this.filteredLanguages = this.performFilter(value);
    if(value != "")
      {
        this.pageSlice = this.filteredLanguages.slice(0, this.filteredLanguages.length);
      } else this.pageSlice = this.filteredLanguages.slice(0, this.filteredLanguages.length); 
  }

  constructor(private router: Router, private languageService: LanguageService) { }

  ngOnInit(): void {
    this.sub = this.languageService.getLanguages().subscribe({
      next: languages => {
        this.languages = languages;
        this.filteredLanguages = this.languages;
        this.pageSlice = this.filteredLanguages.slice(0, this.filteredLanguages.length);
      },
      error: err => this.errorMessage = err
    }); 
  }

  performFilter(filterBy: string): ILanguage[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.languages.filter((language: ILanguage) => language.name.toLocaleLowerCase().includes(filterBy));
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  onPageChange(event: PageEvent) {
    const startIndex = event.pageIndex * event.pageSize;
    let endIndex = startIndex + event.pageSize;
    if (endIndex > this.languages.length) {
      endIndex = this.languages.length;
    }
    this.pageSlice = this.filteredLanguages.slice(startIndex, endIndex);
  }

  //DELETE and EDIT button

  onDeleteClick(languageToDelete: string) {
    this.languages = this.languages.filter(language => language.name !== languageToDelete);
    this.filteredLanguages = this.performFilter("");
    this.pageSlice = this.filteredLanguages.slice(0, this.filteredLanguages.length);
  }

}