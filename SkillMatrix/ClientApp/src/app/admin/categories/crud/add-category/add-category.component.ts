import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { ICategory } from '../../category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: 'add-category.component.html',
  styleUrls: ['add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {

  constructor(private router: Router,
    private categoryService: CategoryService,
    private snackBarService: SnackBarService,
    private routingService: RoutingService,
    private formBuilder: FormBuilder) { }

  errorMessage: string;
  categoryForm = this.formBuilder.control('', Validators.required);

  goTo(path: string) {
    this.router.navigate([path]);
  }

  ngOnInit(): void {
  }

  saveCategory(): void {
    if (this.categoryForm.valid) {

      if (this.categoryForm.dirty) {
        {
          const category = {
            name : this.categoryForm.value
          }
          this.categoryService.createCategory(category)
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
    this.snackBarService.success(message);
    this.routingService.goTo('/skillmatrix/categories');
  }

  onSaveFail(err: any, message: string = "An error has occured!") {

    this.errorMessage = err; console.log(this.errorMessage);
    this.snackBarService.warn(message);
  }
}
