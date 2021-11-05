import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { environment } from 'src/environments/environment';
import { IUser, IUserLanguage, IUserSkill, Rating } from '../user';
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

  rat: Rating;

  languagesUser: string[];
  languagesRating: string[];

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
        jobTitle: this.user.jobTitle,
        team: this.user.team,
        department: this.user.department,
        location: this.user.location,
        email: this.user.email,
        phone: this.user.telephone
        
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
      language: '',
      languageproficiency: '',
      skill: '',
      skillproficiency: ''
    });
  }

  saveUser(): void {
    this.user.firstName = this.profileForm.value.firstname;
    this.user.surName = this.profileForm.value.surname;
    this.user.jobTitle = this.profileForm.value.jobTitle;
    this.user.team = this.profileForm.value.team;
    this.user.department = this.profileForm.value.department;
    this.user.location = this.profileForm.value.location;
    this.user.email = this.profileForm.value.email;
    this.user.telephone = this.profileForm.value.phone;
    this.userService.updateUser(this.user)
      .subscribe({
        error: err => this.errorMessage = err
      });
  }

  addSkill(): void {
    switch(this.profileForm.value.skillproficiency) {
      case "beginner": this.rat = 1; break;
      case "intermediate": this.rat = 2; break;
      case "advanced": this.rat = 3; break;
      default: this.rat = 0; 
    } 
    if(!this.rat) {
      console.log("choose profi");
    } else {
      this.user.skills.push({skillName: this.profileForm.value.skill, rating: this.rat, skillCategory: "skillcategory"});
    }
  }

  removeSkill(skill: IUserSkill): void {
    this.user.skills = this.user.skills.filter(s => s !== skill);
  }

  addLanguage(): void {
    switch(this.profileForm.value.languageproficiency) {
      case "beginner": this.rat = 1; break;
      case "intermediate": this.rat = 2; break;
      case "advanced": this.rat = 3; break;
      default: this.rat = 0; 
    } 
    if(!this.rat) {
      console.log("choose profi");
    } else {
      this.user.languages.push({language: this.profileForm.value.language, rating: this.rat});
    }
  }

  removeLanguage(language: IUserLanguage): void {
    this.user.languages = this.user.languages.filter(l => l !== language);
  }

  changeLanguage(language: IUserLanguage, proficiency: number): void {

  }
  
}
