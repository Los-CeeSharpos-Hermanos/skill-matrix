import {Component, OnInit} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { UserService } from '../user.service';
import { IUser } from '../user';
import { Router } from '@angular/router';


/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class UserListComponent implements OnInit {
  dataSource:IUser[];
  columnsToDisplay = ['surName', 'firstName', 'skill', 'department'];
  expandedElement: IUser | null;
  users: IUser[];

  constructor(private router: Router, private userService:UserService) {}

  ngOnInit(): void {
    //We want to load our users data here
    this.loadUsers();
  }


private loadUsers() {
  this.userService.getUsers().subscribe({
    next: users => {
      this.users = users;
      this.dataSource =users
    } ,
    error: err =>console.log(err)
  })
  }
  goTo(path: string) {
    this.router.navigate([path]);

}
}

