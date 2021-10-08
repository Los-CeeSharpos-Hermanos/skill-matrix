import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialsModule } from './shared/materials/materials.module';
import { LanguagesComponent } from './admin/languages/languages.component';
import { AdminNavbarComponent } from './admin/admin-navbar.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LanguagelistComponent } from './admin/languages/languagelist.component';
import { WelcomeComponent } from './welcome.component';
import { AddLanguageComponent } from './admin/languages/add-language.component';
import { CommonModule } from '@angular/common';
import { ToolbarComponent } from './shared/components/toolbar/toolbar.component';
import { ExpandableTableComponent } from './expandable-table/expandable-table.component';


@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    AdminNavbarComponent,
    LanguagesComponent,
    LanguagelistComponent,
    AddLanguageComponent,
    ToolbarComponent,
    ExpandableTableComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'skillmatrix/editLanguages', component: LanguagesComponent },
      { path: 'skillmatrix/editLanguagesList', component: LanguagelistComponent},
      { path: 'skillmatrix/addLanguage', component: AddLanguageComponent},
      { path: 'skillmatrix/welcome', component: WelcomeComponent},
      { path: 'skillmatrix/admin', component: AdminNavbarComponent},
      { path: '', redirectTo: 'welcome', pathMatch: 'full'},
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
