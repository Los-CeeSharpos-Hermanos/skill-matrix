import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  pageTitle = 'Sign In';
  signInForm: FormGroup;
  registerNewUserForm: FormGroup;

  constructor(private fb: FormBuilder, private routingService: RoutingService, private authenticationService: AuthenticationService) { }

  ngOnInit(): void {

    this.signInForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });

    this.registerNewUserForm = this.fb.group({
      firstName: ['', Validators.required],
      surName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      passwordConfirmation: ['', Validators.required],
    }, { validator: this.checkPasswords });
  }



  SignIn() {
    const { email, password } = this.signInForm.value;

    if (email && password) {
      this.authenticationService.login(email, password)
        .subscribe(() => this.routingService.goTo('skillmatrix/users'));
    }
  }

  SignUp() {
    const { email, password, passwordConfirmation, firstName, surName } = this.registerNewUserForm.value;

    if (email && password && passwordConfirmation && firstName && surName) {
      this.authenticationService.registerNewUser({ email, password, passwordConfirmation, firstName, surName })
        .subscribe(() => this.routingService.goTo('skillmatrix/users/profile'));
    }
  }

  checkPasswords(group: FormGroup) {
    let pass = group.controls.password.value;
    let confirmPass = group.controls.passwordConfirmation.value;
    return pass === confirmPass ? null : { notSame: true };
  }

}

