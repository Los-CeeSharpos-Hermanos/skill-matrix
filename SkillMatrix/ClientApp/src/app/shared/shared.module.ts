import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { AddButtonComponent } from './components/add-button/add-button.component';
import { GoBackButtonComponent } from './components/go-back-button/go-back-button.component';
import { MatRatedChipsComponent } from './components/mat-rated-chips/mat-rated-chips.component';
import { SubmenuComponent } from './components/submenu/submenu.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { SkillMatrixMockDb } from './database/fake-in-memory-db';
import { MaterialsModule } from './materials/materials.module';



@NgModule({
  declarations: [
    ToolbarComponent,
    AddButtonComponent,
    SubmenuComponent,
    GoBackButtonComponent,
    MatRatedChipsComponent
  ],
  exports: [
    CommonModule,
    MaterialsModule,
    ToolbarComponent,
    SubmenuComponent,
    GoBackButtonComponent,
    ReactiveFormsModule,
    AddButtonComponent,
    MatRatedChipsComponent
  ],
  imports: [
    CommonModule,
    MaterialsModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    InMemoryWebApiModule.forRoot(SkillMatrixMockDb, { apiBase: SkillMatrixMockDb.apiBase, passThruUnknownUrl: true }),
  ]
})
export class SharedModule { }
