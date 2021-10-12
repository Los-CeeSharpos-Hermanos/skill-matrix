import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CRUDComponent } from './crud/crud.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddCategoryComponent } from './crud/add-category/add-category.component';
import { EditCategoryComponent } from './crud/edit-category/edit-category.component';


@NgModule({
  declarations: [
    CRUDComponent,
    AddCategoryComponent,
    EditCategoryComponent
  ],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    SharedModule
  ],
  exports:
  [
    CRUDComponent
  ]
})
export class CategoriesModule { }
