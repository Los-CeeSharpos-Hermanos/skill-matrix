import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
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
  category: ICategory;

  there = "skillmatrix/categories/add";

  displayedColumns: string[] = ['name', 'buttons'];

  constructor(private router: Router,
    private categoryService: CategoryService,
    private snackBarService: SnackBarService,
    private routingService: RoutingService
    ) { }

    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  goToEdit(id: number) {
    let url = 'skillmatrix/categories';
    this.routingService.goTo(`${url}/${id}`);
  }

  ngOnInit(): void {
    this.loadCategories();
    console.log(JSON.stringify(this.dataSource));
  }

  private loadCategories() {
    this.categoryService.readCategories().subscribe({
      next: categories => {
        this.categories = categories;
        console.log(categories)
        this.dataSource = new MatTableDataSource(categories);
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }

  deleteCategory(id: number): void {
    if (id === 0)
    {
      this.onDeleteFail("Invalid id");
    }
    else
    {
      if (confirm(`Are you sure you want to delete the category: ${id}`)) {
        this.categoryService.deleteCategory(id)
          .subscribe({
            next: () => this.onDeleteComplete("Category deleted successfully!"),
            error: err => this.onDeleteFail(err)
          });

      }
    }
  }

    onDeleteComplete(message: string = "Category deleted successfully!") {
      this.loadCategories();
      this.snackBarService.success(message);
    }

    onDeleteFail(err: any, message: string = "An error has occured!") {

      this.errorMessage = err; console.log(this.errorMessage);
      this.snackBarService.warn(message);
    }

}
