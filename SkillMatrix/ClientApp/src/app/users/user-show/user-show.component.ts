import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  errorMessage: string;
  public user: IUser = {
    id: 100,
    surName: "Person",
    firstName: "Test",
    telephone: "0123456789",
    email: "test.person@gmail.com",
    jobTitle: "Developer",
    location: "Leipzig",
    department: "Sales",
    team: "A-Team",
    skills: [{skillName: "C#", skillCategory: "Coding", rating: 1}, {skillName: "Java", skillCategory: "Coding", rating: 3}],
    languages: [{language: "german", rating: 2}, {language: "english", rating: 3}],
    imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"}
  constructor(
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private userService: UserService,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.getUser("7");
  }

  goToAddUser(id: number) {
    this.routingService.goTo(`skillmatrix/users/${id}/edit`);
  }

  getUser(id: string): void {
    this.userService.getUser(id)
      .subscribe({
        next: (user: IUser) => this.displayUser(user),
        error: err => this.errorMessage = err
      });
  }

  displayUser(user: IUser): void {
    this.user = user;
    if (this.user.id === 0) {
      console.log("error wrong id");
      
    
    } 
    
  }

}
