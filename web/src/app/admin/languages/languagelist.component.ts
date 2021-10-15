import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { MatPaginator } from '@angular/material/paginator';
import { EditLangugaeService } from './edit-langugae.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { RoutingService } from 'src/app/shared/services/routing.service';

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

  constructor(private routingService: RoutingService, private router: Router, private languageService: LanguageService, private data: EditLangugaeService, private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.loadLanguages();
  }

  goTo(path: string, languageId: number) {
    this.data.changeLanguage(languageId);
    this.router.navigate([path]);
  }

  goToAdd(id: number) {
    this.routingService.goTo(`skillmatrix/languages/${id}/add`)
  }

  onDeleteClick(languageToDelete: number) {
    if (languageToDelete === 0) {
      this.snackBarService.warn("Invalid id");
    } else {
      if (confirm(`Are you sure you want to delete this language?`)) {
        this.languageService.deleteLanguage(languageToDelete)
          .subscribe({
            next: () => this.loadLanguages(),
            error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });
        this.snackBarService.success("Language successful deleted");
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