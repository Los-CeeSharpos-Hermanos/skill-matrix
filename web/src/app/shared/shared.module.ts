import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GoBackButtonComponent } from './components/go-back-button/go-back-button.component';
import { SubmenuComponent } from './components/submenu/submenu.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MaterialsModule } from './materials/materials.module';



@NgModule({
  declarations: [
    ToolbarComponent,
    SubmenuComponent,
    GoBackButtonComponent
  ],
  exports: [
    CommonModule,
    MaterialsModule,
    ToolbarComponent,
    SubmenuComponent,
    GoBackButtonComponent,
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
