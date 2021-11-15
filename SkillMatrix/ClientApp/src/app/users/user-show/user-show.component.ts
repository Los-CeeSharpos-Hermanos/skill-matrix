import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/auth/authentication.service';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { IUser } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-show',
  templateUrl: './user-show.component.html',
  styleUrls: ['./user-show.component.scss']
})
export class UserShowComponent implements OnInit {
  id: string | null;
  errorMessage: string;

  currentUser: IUser;

  constructor(
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private userService: UserService,
    private snackBarService: SnackBarService,
    private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.id = this.authenticationService.getLoggedUser();
    this.getUser();
  }

  goToAddUser(id: string) {
    this.routingService.goTo(`skillmatrix/users/${id}/edit`);
  }

  getUser(): void {
    this.userService.getUser(this.id)
      .subscribe({
        next: (user: IUser) => this.currentUser = user,
        error: err => this.errorMessage = err
      });
  }
}
