import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IUser } from '../user';
import { UserService } from '../user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  errorMessage: string = '';
  sub!: Subscription;
  users: IUser[] = [];
  filteredUsers: IUser[] = [];


  constructor(private router: Router, private userService:UserService) {}

  ngOnInit(): void {
    console.log('user array delivered');
    this.sub = this.userService.getUsers().subscribe({
      next: users => {
        this.users = users;
        this.filteredUsers = this.users;
      },
      error: err => this.errorMessage = err
    });
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }
}
