import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { CategoriesModule } from '../../categories.module';
import { ICategory } from '../../category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {
  displayedColumns: string[] = ['name', 'weight', 'symbol'];

  constructor(private router: Router,
    private formBuilder: FormBuilder,
    private snackBarService: SnackBarService,
    private routingService: RoutingService,
    private categoryService: CategoryService,
    private route: ActivatedRoute) { }

  private sub: Subscription;

  category: ICategory;
  errorMessage: string;
  categoryForm = this.formBuilder.control('', Validators.required);
  pageTitle: string;

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.displayCategory(id);
      });
  }

  displayCategory(id: string)
  {
    this.categoryService.readCategory(id).subscribe({
      next: (category: ICategory) => this.category = category,
      error: err => this.errorMessage = err
    });

    // this.pageTitle = `Editing Category: ${this.category.name}`;

    // this.categoryForm.patchValue({
    //   categoryName: this.category.name
    // })
  }

  saveCategory(): void {


    if (this.categoryForm.valid) {

      if (this.categoryForm.dirty)
      {
        this.category.name = this.categoryForm.value;
       
          this.categoryService.updateCategory(this.category)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });
      }
      else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct validation errors";
      console.log(this.errorMessage);
    }
  }

  onSaveComplete(message: string = "Category edited!") {
    this.categoryForm.reset();
    this.snackBarService.success(message);
    this.routingService.goTo('/skillmatrix/categories');
  }

  onSaveFail(err: any, message: string = "An error has occured!") {

    this.errorMessage = err; console.log(this.errorMessage);
    this.snackBarService.warn(message);
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }
}
