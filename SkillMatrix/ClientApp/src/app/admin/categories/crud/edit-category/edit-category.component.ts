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

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.categoryService.readCategory(id);
      });
  }

  saveCategory(): void {
    if (this.categoryForm.valid) {

      if (this.categoryForm.dirty) {
        const editedCategory = { ...this.category, ...this.categoryForm.value };
        {
          this.categoryService.updateCategory(editedCategory)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct validation errors";
      console.log(this.errorMessage);
    }
  }

  onSaveComplete(message: string = "Category added!") {
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
