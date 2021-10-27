import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileForm: FormGroup;
  categoriesList: ['Frontend', 'Backend', 'Databases', 'Cloud expertise'];
  
  profilePic: string = "assets/dogPic2.jpg";

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {

    this.profileFormInit();

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
      languages: this.fb.array([this.buildLanguage()]),
      skills: this.fb.array([this.buildSkill()])
    });
  }

  categoriesListInit() {

    //To do:
    //1. Grab categories from backend/fakeapi
    //2. Turn them into an array of strings

    this.categoriesList = ['Frontend', 'Backend', 'Databases', 'Cloud expertise'];

  }

  buildSkill(): FormGroup {
    return this.fb.group({
      skillName: '',
      proficiency: ''
    });
  }

  get skills(): FormArray {
    return this.profileForm.get('skills') as FormArray;
  }

  addSkill() : void
  {
    this.skills.push(this.buildSkill())
  }

  removeSkill(index: number) : void
  {
    this.skills.removeAt(index);
  }

  buildLanguage(): FormGroup {
    return this.fb.group({
      language: '',
      proficiency: ''
    });
  }

  get languages(): FormArray {
    return this.profileForm.get('languages') as FormArray;
  }

  addLanguage() : void
  {
    this.languages.push(this.buildLanguage())
  }

  removeLanguage(index: number): void
  {
    this.languages.removeAt(index);
  }
}
