import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AdminNavbarComponent } from './admin/admin-navbar.component';
import { AddLanguageComponent } from './admin/languages/add-language.component';
import { LanguagelistComponent } from './admin/languages/languagelist.component';
import { LanguagesComponent } from './admin/languages/languages.component';
import { SkillDetailComponent } from './admin/skills/skill-detail/skill-detail.component';
import { SkillEditComponent } from './admin/skills/skill-edit/skill-edit.component';
import { SkillListComponent } from './admin/skills/skill-list/skill-list.component';
import { SkillsComponent } from './admin/skills/skills.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialsModule } from './shared/materials/materials.module';
import { WelcomeComponent } from './welcome.component';
import { SkillModule } from './admin/skills/skill.module';



@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    AdminNavbarComponent,
    LanguagesComponent,
    LanguagelistComponent,
    AddLanguageComponent
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
      { path: 'skillmatrix/editLanguagesList', component: LanguagelistComponent },
      { path: 'skillmatrix/addLanguage', component: AddLanguageComponent },
      { path: 'skillmatrix/welcome', component: WelcomeComponent },
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
