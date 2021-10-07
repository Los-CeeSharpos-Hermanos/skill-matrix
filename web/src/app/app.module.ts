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

@NgModule({
  declarations: [
    AppComponent,
    AdminNavbarComponent,
    LanguagesComponent,
    LanguagelistComponent,
    AddLanguageComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'editLanguages', component: LanguagesComponent },
      { path: 'editLanguagesList', component: LanguagelistComponent},
      { path: 'addLanguage', component: AddLanguageComponent},
      { path: 'welcome', component: WelcomeComponent},
      { path: 'admin', component: AdminNavbarComponent},
      { path: '', redirectTo: 'welcome', pathMatch: 'full'},
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
