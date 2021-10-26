import {Component, OnInit, ViewChild} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { UserService } from '../user.service';
import { IUser } from '../user';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';


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
  dataSource: MatTableDataSource<IUser>;
  errorMessage: string = '';
  columnsToDisplay = ['surName', 'firstName', 'skill', 'department'];
  expandedElement: IUser | null;
  users: IUser[];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private router: Router, private userService:UserService, private snackBarService:SnackBarService) {}

  ngOnInit(): void {
    //We want to load our users data here
    this.loadUsers();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  private loadUsers() {
  this.userService.getUsers().subscribe({
    next: users => {
      this.users = users;
      this.dataSource = new MatTableDataSource(this.users);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;

    } ,
    error: err =>console.log(err)
  })
  }

  onDeleteClick(userToDelete: number) {
    if (userToDelete === 0) {
      this.snackBarService.warn("Invalid id");
    } else {
      if (confirm(`Are you sure you want to delete this language?`)) {
        this.userService.deleteUser(userToDelete)
          .subscribe({
            next: () => this.loadUsers(),
            error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });
        this.snackBarService.success("Language successful deleted");
      }
    }
  }

  goTo(path: string) {
    this.router.navigate([path]);
}
}

