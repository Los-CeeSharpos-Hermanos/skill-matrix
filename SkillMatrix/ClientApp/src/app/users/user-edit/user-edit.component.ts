import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  isChanged: boolean;

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

  rating: Rating;
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
    this.isChanged = false;
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
      languageproficiencyChange: '',
      skill: '',
      skillproficiency: '',
      skillproficiencyChange: ''
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
    this.goToUser();
  }

  addSkill(): void {
    switch(this.profileForm.value.skillproficiency) {
      case "beginner": this.rating = 1; break;
      case "intermediate": this.rating = 2; break;
      case "advanced": this.rating = 3; break;
      default: this.rating = 0; 
    } 
    if(!this.rating) {
      console.log("choose profi");
    } else {
      this.user.skills.push({skillName: this.profileForm.value.skill, rating: this.rating, skillCategory: "skillcategory"});

      this.profileForm.patchValue({
        skill: "",
        skillproficiency: ""
      });
    }
  }

  removeSkill(skill: IUserSkill): void {
    this.user.skills = this.user.skills.filter(s => s !== skill);
  }

  changeSkill(skill: IUserSkill): void {
    if(this.profileForm.value.skillproficiencyChange != "") {
      var index = this.user.skills.lastIndexOf(skill);
      switch(this.profileForm.value.skillproficiencyChange) {
        case "beginner": this.user.skills[index].rating = 1; break;
        case "intermediate": this.user.skills[index].rating = 2; break;
        case "advanced": this.user.skills[index].rating = 3; break;
        default: break; 
      } 
    }
  }

  addLanguage(): void {
    switch(this.profileForm.value.languageproficiency) {
      case "beginner": this.rating = 1; break;
      case "intermediate": this.rating = 2; break;
      case "advanced": this.rating = 3; break;
      default: this.rating = 0; 
    } 
    if(!this.rating) {
      console.log("choose profi");
    } else {
      var index = this.user.languages.indexOf({language: this.profileForm.value.language, rating: this.rating});
      if(index === -1)
      {
        this.user.languages.push({language: this.profileForm.value.language, rating: this.rating});
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

  changeLanguage(language: IUserLanguage): void {
    if(this.profileForm.value.languageproficiencyChange != "") {
      var index = this.user.languages.lastIndexOf(language);
      switch(this.profileForm.value.languageproficiencyChange) {
        case "beginner": this.user.languages[index].rating = 1; break;
        case "intermediate": this.user.languages[index].rating = 2; break;
        case "advanced": this.user.languages[index].rating = 3; break;
        default: break; 
      } 
    }
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

  goToUser() {
    this.routingService.goTo(`skillmatrix/users/profile`);
  }
}
