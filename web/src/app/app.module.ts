import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AdminNavbarComponent } from './admin/admin-navbar.component';
import { AddLanguageComponent } from './admin/languages/add-language.component';
import { LanguagelistComponent } from './admin/languages/languagelist.component';
import { LanguagesComponent } from './admin/languages/languages.component';
import { SkillModule } from './admin/skills/skill.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialsModule } from './shared/materials/materials.module';

@NgModule({
  declarations: [
    AppComponent,
    AdminNavbarComponent,
    LanguagesComponent,
    LanguagelistComponent,
    AddLanguageComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialsModule,
    MatCardModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'skillmatrix/editLanguages', component: LanguagesComponent },
      { path: 'skillmatrix/editLanguagesList', component: LanguagelistComponent },
      { path: 'skillmatrix/addLanguage', component: AddLanguageComponent },
      { path: 'skillmatrix/admin', component: AdminNavbarComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
    ]),
    SkillModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
