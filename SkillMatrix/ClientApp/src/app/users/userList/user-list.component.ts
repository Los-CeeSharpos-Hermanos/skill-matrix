import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUser, IUserHability, IUserLanguage, IUserSkill, Rating } from '../user';
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
  dataSource: IUser[];
  columnsToDisplay: IExpandableTableColumn[] = [
    {
      id: 'surName',
      name: 'Surname',
      columnStyle: ColumnStyle.Text
    },
    {
      id: 'firstName',
      name: 'First Name',
      columnStyle: ColumnStyle.Text
    },
    {
      id: 'skills',
      name: 'Skills',
      columnStyle: ColumnStyle.Chips
    },
    {
      id: 'languages',
      name: 'Languages',
      columnStyle: ColumnStyle.Chips
    },
    {
      id: 'department',
      name: 'Department',
      columnStyle: ColumnStyle.Text
    },
  ];

  displayedColumns: string[] = this.columnsToDisplay.map(col => col.id);
  expandedElement: IUser | null;
  users: IUser[];

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit(): void {
    //We want to load our users data here
    this.loadUsers();
  }

  goTo(path: string) {
    this.router.navigate([path]);

  }

  isChip(columnStyle: ColumnStyle): boolean {
    return columnStyle == ColumnStyle.Chips;
  }

  isSkills(columnName: string): boolean {
    return columnName == 'skills';
  }

  isLanguages(columnName: string): boolean {
    return columnName == 'languages';
  }

  GetTopThreeSkills(skills: IUserSkill[]): IUserSkill[] {
    return this.GetTopHabilities(skills, 3) as IUserSkill[];
  }

  GetTopThreeLanguages(languages: IUserLanguage[]): IUserLanguage[] {
    return this.GetTopHabilities(languages, 3) as IUserLanguage[];
  }

  getRatingColor(rating: Rating) {
    switch (rating) {
      case Rating.Intermediate:
        return {
          'intermediate': true
        };
      case Rating.Advanced:
        return {
          'advanced': true
        };

      default:
        return '';
    }
  }
  private loadUsers() {
    this.userService.getUsers().subscribe({
      next: users => {
        this.users = users;
        this.dataSource = users;
      },
      error: err => console.log(err)
    });
  }


  private GetTopHabilities<T extends IUserHability>(habilities: T[], listSize: number) {
    if (listSize - 1 < 0) {
      throw Error("Only positive numbers are accepted");
    }

    return habilities.sort((a, b) => b.rating - a.rating).slice(0, listSize - 1);
  }

}

