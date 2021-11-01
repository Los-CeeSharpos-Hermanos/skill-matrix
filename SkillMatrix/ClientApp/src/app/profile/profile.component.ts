import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ICategory } from '../admin/categories/category';
import { CategoryService } from '../admin/categories/crud/services/category.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {

  profileForm: FormGroup;
  profilePic: string = "assets/dogPic2.jpg";

  notRetrievedCategories = ['Frontend', 'Backend', 'Databases', 'Cloud Expertise', 'People Skils'];
  retrievedCategories: ICategory[];
  retrievedLanguages: [''];
  retrievedSkills: [''];
  errorMessage: '';

  myControl = new FormControl();
  filteredOptions: Observable<string[]>;

  filterInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.notRetrievedCategories.filter(option => option.toLowerCase().includes(filterValue));
  }

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService) { }

  ngOnInit(): void {

    this.profileFormInit();

    this.categoriesInit();

    this.filterInit();
  }

  categoriesInit() {
    this.categoryService.readCategories().subscribe({
      next: categories =>
      {
        this.retrievedCategories = categories;
      },
      error: err => { this.errorMessage = err; console.log(err);}
    });
  }

  private profileFormInit() {
    this.profileForm = this.fb.group({
      firstname: '',
      surname: '',
      jobTitle: '',
      team: '',
      department: '',
      location: '',
      email: ['', [Validators.email]],
      phone: '',
      favQuote: '',
      languages: this.fb.array([this.buildFormLanguage()]),
      skills: this.fb.array([this.buildFormSkill()])
    });
  }

  buildFormSkill(): FormGroup {
    return this.fb.group({
      skillName: '',
      proficiency: ''
    });
  }

  get formSkills(): FormArray {
    return this.profileForm.get('skills') as FormArray;
  }

  addFormSkill() : void
  {
    this.formSkills.push(this.buildFormSkill())
  }

  removeFormSkill(index: number) : void
  {
    this.formSkills.removeAt(index);
  }

  buildFormLanguage(): FormGroup {
    return this.fb.group({
      language: '',
      proficiency: ''
    });
  }

  get formLanguages(): FormArray {
    return this.profileForm.get('languages') as FormArray;
  }

  addFormLanguage() : void
  {
    this.formLanguages.push(this.buildFormLanguage())
  }

  removeFormLanguage(index: number): void
  {
    this.formLanguages.removeAt(index);
  }
}


