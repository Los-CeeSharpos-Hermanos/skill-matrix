import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MaterialsModule } from './materials/materials.module';



@NgModule({
  declarations: [
    ToolbarComponent
  ],
  exports: [
    CommonModule,
    MaterialsModule,
    ToolbarComponent,
    ReactiveFormsModule,
  ],
  imports: [
    CommonModule,
    MaterialsModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ]
})
export class SharedModule { }
