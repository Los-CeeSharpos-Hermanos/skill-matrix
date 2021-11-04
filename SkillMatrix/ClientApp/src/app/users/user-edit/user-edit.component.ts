import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { environment } from 'src/environments/environment';
import { IUser } from '../user';
import { UserService } from '../user.service';


@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {

  profileForm: FormGroup;
  categoriesList: ['Frontend', 'Backend', 'Databases', 'Cloud expertise'];

  profilePic = environment.profilePic;
  private sub: Subscription;
  pageTitle: string;
  errorMessage: string;
  user: IUser;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private userService: UserService,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {

    this.profileFormInit();
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.getUser(id);
      });
  }

  getUser(id: string): void {
    this.userService.getUser(id)
      .subscribe({
        next: (user: IUser) => this.displayUser(user),
        error: err => this.errorMessage = err
      });
  }

  displayUser(user: IUser): void {
    if (this.profileForm) {
      this.profileForm.reset();
    }

    this.user = user;
    if (this.user.id === 0) {
      this.pageTitle = 'Add a new User';
      
    
    } else {
      this.profilePic = this.user.imageUrl;
      this.pageTitle = `Editing User: ${this.user.firstName} ${this.user.surName}`;
      this.profileForm.patchValue({
        firstname: this.user.firstName,
        surname: this.user.surName,
        jobTitle: '',
        team: this.user.team,
        department: this.user.department,
        location: '',
        email: this.user.email,
        phone: this.user.telephone,
        favQuote: ''
      });
    }

    
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

  addSkill(): void {
    this.skills.push(this.buildSkill());
  }

  removeSkill(index: number): void {
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

  addLanguage(): void {
    this.languages.push(this.buildLanguage());
  }

  removeLanguage(index: number): void {
    this.languages.removeAt(index);
  }
}
