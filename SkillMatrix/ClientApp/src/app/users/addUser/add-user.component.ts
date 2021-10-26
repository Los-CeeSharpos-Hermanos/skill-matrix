import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { UserService } from 'src/app/users/user.service';
import { IUser } from '../user';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private userService: UserService,
    private snackBarService: SnackBarService) { }

  private sub: Subscription;

  errorMessage: string;
  pageTitle: string;
  language: IUser;
  isThere: Boolean = false;
  users: IUser[] = [];
  user: IUser;

  userForm = this.fb.group
  ({
    firstName : ['', Validators.required],
    surName : ['', Validators.required],
    email : ['', Validators.required],
    skill : ['', Validators.required],
    language : ['', Validators.required],
    team : ['', Validators.required],
    department : ['', Validators.required],
  });

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.getUser(id);
      });
  }

  getUser(id: string): void{
    this.userService.getUser(id).subscribe({
      next: (user: IUser) => this.displayUser(user),
      error: err => this.errorMessage = err
    });
  }

  displayUser(user: IUser): void{
    if (this.userForm){
      this.userForm.reset();
    }

    
    this.user = user;

    if (this.user.id === 0){
      this.pageTitle = 'add a new user';
    } else{
      this.pageTitle = `edit user: ${this.user.firstName}`;
    }
    this.userForm.patchValue({
      firstName: this.user.firstName,
      surName: this.user.surName,
      email: this.user.email,
      skill: this.user.skill,
      language: this.user.language,
      team: this.user.team,
      department: this.user.department,
    })
  }

  editUser(user: IUser): void {
    this.userService.updateUser(user)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
  }

  saveUser(): void {
    if (this.userForm.valid) {

      if (this.userForm.dirty) {
        const l = { ...this.user, ...this.userForm.value };
        if (l.id == 0) {

          this.userService.createUser(l)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });

        } else {
          this.userService.updateUser(l)
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
    this.userForm.reset();
    this.snackBarService.success(message);
    this.routingService.goTo('/skillmatrix/members');
  }

  onSaveFail(err: any, message: string = "An error has occured!") {

    this.errorMessage = err; console.log(this.errorMessage);
    this.snackBarService.warn(message);
  }


  }




