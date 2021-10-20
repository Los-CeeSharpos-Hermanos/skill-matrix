import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddLanguageComponent } from './components/editLanguage/add-language.component';
import { LanguagelistComponent } from './components/languagelist/languagelist.component';
import { LanguagesComponent } from './components/languages/languages.component';


@NgModule({
  declarations: [
    LanguagesComponent,
    LanguagelistComponent,
    AddLanguageComponent,
  ],
  imports: [
    RouterModule.forChild([
      { path: 'skillmatrix/languages/:id', component: LanguagesComponent },
      { path: 'skillmatrix/languages', component: LanguagelistComponent },
      { path: 'skillmatrix/languages/:id/add', component: AddLanguageComponent },
    ]),
    SharedModule,
    FormsModule
  ]
})
export class LanguageModule { }
