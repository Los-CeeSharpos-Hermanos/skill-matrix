import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})



export class ProfileComponent implements OnInit {

  profileForm: FormGroup;
  profilePic: string = "assets/dogPic2.jpg";

  languages: [''];
  skills: [''];



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
      languages: this.fb.array([this.buildFormLanguage()]),
      skills: this.fb.array([this.buildSkill()])
    });
  }

  buildSkill(): FormGroup {
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
    this.formSkills.push(this.buildSkill())
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


