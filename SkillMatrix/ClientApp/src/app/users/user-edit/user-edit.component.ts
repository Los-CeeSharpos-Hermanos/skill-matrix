import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILanguage } from 'src/app/admin/languages/language';
import { LanguageService } from 'src/app/admin/languages/services/language.service';
import { SkillService } from 'src/app/admin/skills/services/skill.service';
import { Skill } from 'src/app/admin/skills/skill';
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
  user: IUser = {
    id: 0,
    firstName: "",
    surName: "",
    department: "",
    team: "",
    telephone: "",
    email: "",
    location: "",
    jobTitle: "",
    imageUrl: "",
    languages: [
      {
        language: "",
        rating: 1
      }
    ],
    skills: [
      {
        skillName: "",
        skillCategory: "",
        rating: 1
      }
    ]
  };

  rat: Rating;
  allLanguages: ILanguage[] = [];
  allSkills: Skill[] = [];

  languagesUser: string[];
  languagesRating: string[];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private skillService: SkillService,
    private routingService: RoutingService,
    private userService: UserService,
    private languageService: LanguageService,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {

    this.loadAll();

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
      this.profileForm.patchValue({
        skill: "",
        skillproficiency: ""
      });
    }
  }

  removeSkill(skill: IUserSkill): void {
    this.user.skills = this.user.skills.filter(s => s !== skill);
  }

  changeSkill(skill: IUserSkill, proficiency: number): void {

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
      var index = this.user.languages.indexOf({language: this.profileForm.value.language, rating: this.rat});
      console.log(index);
      console.log(this.user.languages);
      if(index === -1)
      {
        this.user.languages.push({language: this.profileForm.value.language, rating: this.rat});
      }
      
      this.profileForm.patchValue({
        language: "",
        languageproficiency: ""
      });
    }
  }

  removeLanguage(language: IUserLanguage): void {
    this.user.languages = this.user.languages.filter(l => l !== language);
  }

  changeLanguage(language: IUserLanguage, proficiency: number): void {

  }

  private loadAll() {
    this.languageService.getLanguages().subscribe({
      next: languages => {
        this.allLanguages = languages;
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
    this.skillService.listSkills().subscribe({
      next: skills => {
        this.allSkills = skills;
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }
}
