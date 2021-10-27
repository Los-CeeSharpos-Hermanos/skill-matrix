import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { CategoriesModule } from './admin/categories/categories.module';
import { LanguageModule } from './admin/languages/language.module';
import { SkillModule } from './admin/skills/skill.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './users/user.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'skillmatrix/users', pathMatch: 'full' },
      { path: '**', redirectTo: 'skillmatrix/users', pathMatch: 'full' }
    ]),
    SharedModule,
    LanguageModule,
    CategoriesModule,
    SkillModule,
    UserModule
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
