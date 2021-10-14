import { Component, OnInit } from '@angular/core';
import { ILanguage } from './language';
import { LanguageService } from './language.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { FormBuilder, Validators } from '@angular/forms';
import { RoutingService } from 'src/app/shared/services/routing.service';


@Component({
  selector: 'app-add-language',
  templateUrl: './add-language.component.html',
  styleUrls: ['./add-language.component.scss']
})

export class AddLanguageComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private languageService: LanguageService,
    private snackBarService: SnackBarService) { }

  private sub: Subscription;

  errorMessage: string;
  pageTitle: string;
  language: ILanguage;

  languageForm = this.fb.group({
    name: ['', Validators.required],
    nativeName: ['', Validators.required],
    code: ['', Validators.required],
  });


  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.getLanguage(id);
      });
  }

  getLanguage(id: string): void {
    this.languageService.getLanguage(id)
      .subscribe({
        next: (language: ILanguage) => this.displayLanguage(language),
        error: err => this.errorMessage = err
      });
  }

  displayLanguage(language: ILanguage): void {
    if (this.languageForm) {
      this.languageForm.reset();
    }

    this.language = language;
    if (this.language.id === 0) {
      this.pageTitle = 'Add a new Language';
    } else {
      this.pageTitle = `Editing Language: ${this.language.name}`;
    }

    this.languageForm.patchValue({
      name: this.language.name,
      nativeName: this.language.nativeName,
      code: this.language.code
    });
  }


  editLanguage(language: ILanguage): void {
    this.languageService.updateLanguage(language)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
  }

  saveLanguage(): void {
    if (this.languageForm.valid) {

      if (this.languageForm.dirty) {
        const l = { ...this.language, ...this.languageForm.value };
        console.log(l);
        console.log(this.languageForm.value);
        if (l.id == 0) {

          this.languageService.createLanguage(l)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });

        } else {
          this.languageService.updateLanguage(l)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct validation errors";
      console.log(this.errorMessage);
    }
  }

  onSaveComplete(message: string = "Language saved!") {
    this.languageForm.reset();
    this.snackBarService.success(message);
    this.routingService.goTo('/skillmatrix/languages');
  }

  onSaveFail(err: any, message: string = "An error has occured!") {

    this.errorMessage = err; console.log(this.errorMessage);
    this.snackBarService.warn(message);
  }
}
