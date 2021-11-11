import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { CategoriesModule } from './admin/categories/categories.module';
import { LanguageModule } from './admin/languages/language.module';
import { SkillModule } from './admin/skills/skill.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthenticationInterceptor } from './interceptors/authentication.interceptor';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './users/user.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: '**', component: LoginComponent }
      // { path: '', redirectTo: 'skillmatrix/users', pathMatch: 'full' },
      // { path: '**', redirectTo: 'skillmatrix/users', pathMatch: 'full' }
    ]),
    SharedModule,
    LanguageModule,
    CategoriesModule,
    SkillModule,
    UserModule
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
