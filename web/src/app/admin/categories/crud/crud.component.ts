import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ICategory } from '../category';
import { CategoryService } from './services/category.service';

// was here the thing

@Component({
  selector: 'categories-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})

export class CRUDComponent implements OnInit {

  categories: ICategory[];
  dataSource: MatTableDataSource<ICategory>;
  errorMessage: "";
  pageTitle: "Skill Categories";

  there = "skillmatrix/categories/add";


  displayedColumns: string[] = ['name', 'member', 'buttons'];

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(private router: Router, private categoryService: CategoryService) { }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  ngOnInit(): void {
    this.loadCategories();
    console.log(JSON.stringify(this.dataSource));
  }

  private loadCategories() {
    this.categoryService.listCategories().subscribe({
      next: categories => {
        this.categories = categories;
        console.log(categories)
        this.dataSource = new MatTableDataSource(categories);
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }

}
