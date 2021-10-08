import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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
    ToolbarComponent
  ],
  imports: [
    CommonModule,
    MaterialsModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
  ]
})
export class SharedModule { }
