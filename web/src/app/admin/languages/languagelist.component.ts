import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { MatPaginator } from '@angular/material/paginator';
import { EditLangugaeService } from './edit-langugae.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-languagelist',
  templateUrl: './languagelist.component.html',
  styleUrls: ['./languagelist.component.scss']
})
export class LanguagelistComponent implements OnInit {
  displayedColumns: string[] = ['language', 'nativeName', 'action'];
  errorMessage: string = '';
  sub!: Subscription;
  
  languages: ILanguage[] = [];
  languageToEdit: number;
  dataSource: MatTableDataSource<ILanguage>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private router: Router, private languageService: LanguageService, private data: EditLangugaeService) { }

  ngOnInit(): void {
    this.loadLanguages();
  }

  performFilter(filterBy: string): ILanguage[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.languages.filter((language: ILanguage) => language.name.toLocaleLowerCase().includes(filterBy));
  }

  goTo(path: string, languageId: number) {
    this.data.changeLanguage(languageId);
    this.router.navigate([path]);
  }

  onDeleteClick(languageToDelete: number) {
    if (languageToDelete === 0) {
      alert("Invalid id");
    } else {
      console.log(languageToDelete);
      if (confirm(`Are you sure you want to delete this language?`)) {
        console.log("confirmed");
        this.languageService.deleteLanguage(languageToDelete)
          .subscribe({
            next: () => this.loadLanguages(),
            error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });
      }
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  private loadLanguages() {
    this.languageService.getLanguages().subscribe({
      next: languages => {
        this.languages = languages;
        this.dataSource = new MatTableDataSource(this.languages);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }
}