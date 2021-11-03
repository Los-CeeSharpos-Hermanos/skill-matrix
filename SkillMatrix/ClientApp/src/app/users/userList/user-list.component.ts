import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { users } from 'src/app/shared/database/members/members-data';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { environment } from 'src/environments/environment';
import { IUser, IUserHability, IUserLanguage, IUserSkill } from '../user';
import { UserService } from '../user.service';
import { ColumnStyle, IExpandableTableColumn } from './expandable-table-column';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class UserListComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private snackBarService: SnackBarService, private routingService: RoutingService, private userService: UserService) { }

  profilePicPlaceholder = environment.profilePic;
  dataSource: MatTableDataSource<IUser>;
  columnsToDisplay: IExpandableTableColumn[] = [
    {
      id: 'surName',
      name: 'Surname',
      columnStyle: ColumnStyle.SimpleText
    },
    {
      id: 'firstName',
      name: 'First Name',
      columnStyle: ColumnStyle.SimpleText
    },
    {
      id: 'skills',
      name: 'Skills',
      columnStyle: ColumnStyle.JoinedArray
    },
    {
      id: 'languages',
      name: 'Languages',
      columnStyle: ColumnStyle.JoinedArray
    },
    {
      id: 'department',
      name: 'Department',
      columnStyle: ColumnStyle.SimpleText
    },
    {
      id: 'actions',
      name: 'Actions',
      columnStyle: ColumnStyle.SimpleText
    },
  ];

  displayedColumns: string[] = this.columnsToDisplay.map(col => col.id);
  expandedElement: IUser | null;
  users: IUser[];
  errorMessage: '';
  isHidden = true;

  ngOnInit(): void {
    this.loadUsers();

    this.hideUser();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToAddUser() {
    this.routingService.goTo('skillmatrix/users/0/edit');
  }

  onDeleteClick(userToDelete: number) {
    if (userToDelete === 0) {
      this.snackBarService.warn("Invalid id");
    } else {
      if (confirm(`Are you sure you want to delete this member?`)) {
        this.userService.deleteUser(userToDelete)
          .subscribe({
            next: () => this.loadUsers(),
            error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });
        this.snackBarService.success("Member successful deleted");
      }
    }
  }

  hideUser() {
    this.isHidden = !this.isHidden;
  }

  isJoinedArray(columnStyle: ColumnStyle): boolean {
    return columnStyle == ColumnStyle.JoinedArray;
  }

  isSkills(columnName: string): boolean {
    return columnName == 'skills';
  }

  isLanguages(columnName: string): boolean {
    return columnName == 'languages';
  }

  isActions(columnName: string): boolean {
    return columnName == 'actions';
  }

  getTopThreeSkills(skills: IUserSkill[]): string {
    return joinWithCommaAndSpace(
      this.getTopHabilities(skills, 3)
        .map(item => item.skillName));
  }

  getTopThreeLanguages(languages: IUserLanguage[]): string {
    return joinWithCommaAndSpace(
      this.getTopHabilities(languages, 3)
        .map(item => item.language));
  }

  private loadUsers() {
    this.userService.getUsers().subscribe({
      next: users => {
        this.users = users;
        this.setupDataSource();
      },
      error: err => console.log(err)
    });
  }


  private getTopHabilities<T extends IUserHability>(habilities: T[], listSize: number) {
    if (listSize - 1 < 0) {
      throw Error("Only positive numbers are accepted");
    }

    return habilities.sort((a, b) => b.rating - a.rating).slice(0, listSize - 1);
  }

  private setupDataSource() {
    this.dataSource = new MatTableDataSource(this.users);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    console.log(this.dataSource);
  }
}

const joinWithCommaAndSpace = (stringArray: string[]) => stringArray.join(', ');
