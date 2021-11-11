import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ILanguage } from 'src/app/admin/languages/language';
import { LanguageService } from 'src/app/admin/languages/services/language.service';
import { SkillService } from 'src/app/admin/skills/services/skill.service';
import { Skill } from 'src/app/admin/skills/skill';
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

  constructor(private fb: FormBuilder,
    private snackBarService: SnackBarService, 
    private routingService: RoutingService, 
    private skillService: SkillService,
    private languageService: LanguageService,
    private userService: UserService) { }

  allSkills: Skill[] = [];
  allLanguages: ILanguage[] = [];
  filterForm: FormGroup;
  removable = true;

  filteredSkills: string[] = [];
  filteredLanguages: string[] = [];
  panelOpenState = false;

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
      name: '',
      columnStyle: ColumnStyle.SimpleText
    },
  ];

  displayedColumns: string[] = this.columnsToDisplay.map(col => col.id);
  expandedElement: IUser | null;
  users: IUser[];
  usersFiltered: IUser[];
  errorMessage: '';
  isHidden = true;

  ngOnInit(): void {
    this.loadUsers();
    this.loadAll();
    this.profileFormInit();
    this.hideUser();
  }

  private profileFormInit() {
    this.filterForm = this.fb.group({
      filterSkill: "",
      filterLanguage: ""
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToAddUser(id: number) {
    this.routingService.goTo(`skillmatrix/users/${id}/edit`);
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
      this.getTopHabilities(skills, 4)
        .map(item => item.skillName));
  }

  getTopThreeLanguages(languages: IUserLanguage[]): string {
    return joinWithCommaAndSpace(
      this.getTopHabilities(languages, 4)
        .map(item => item.language));
  }

  private loadUsers() {
    this.userService.getUsers().subscribe({
      next: users => {
        this.users = users;
        this.usersFiltered = users;
        this.setupDataSource(this.users);
      },
      error: err => console.log(err)
    });
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


  private getTopHabilities<T extends IUserHability>(habilities: T[], listSize: number) {
    if (listSize - 1 < 0) {
      throw Error("Only positive numbers are accepted");
    }

    return habilities.sort((a, b) => b.rating - a.rating).slice(0, listSize - 1);
  }

  private setupDataSource(users: IUser[]) {
    this.dataSource = new MatTableDataSource(users);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  addSkillFilter() {
    if(!this.filteredSkills.includes(this.filterForm.value.filterSkill) && this.filterForm.value.filterSkill != "") {
      this.filteredSkills.push(this.filterForm.value.filterSkill);
    }
    this.skillFilter(this.usersFiltered, this.filteredSkills);
  }

  removeLanguageFilter(language: String) {
      this.filteredLanguages = this.filteredLanguages.filter(l => l !== language);
      this.languageFilter(this.usersFiltered, this.filteredLanguages);
  }

  addLanguageFilter() {
    if(!this.filteredLanguages.includes(this.filterForm.value.filterLanguage) && this.filterForm.value.filterLanguage != "") {
      this.filteredLanguages.push(this.filterForm.value.filterLanguage);
    }
    this.languageFilter(this.usersFiltered, this.filteredLanguages);
  }

  removeSkillFilter(skill: String) {
    this.filteredSkills = this.filteredSkills.filter(s => s !== skill);
    this.skillFilter(this.usersFiltered, this.filteredSkills);
  
  }

  skillFilter(usersFiltered: IUser[], filteredSkills: string[] ) {
    var isIn = false;
    for(let k=0;k<filteredSkills.length;k++) {
      for(let i=0;i<this.users.length;i++) {
        for(let j=0;j<this.users[i].skills.length;j++) {
          if(this.users[i].skills[j].skillName === filteredSkills[k]) {
            isIn=true;
          }
        }
        if(!isIn) {
          usersFiltered = usersFiltered.filter(u => u !== this.users[i])
        } else {
          isIn = false;
        }
      }
    }
    this.setupDataSource(usersFiltered);
  }

  languageFilter(usersFiltered: IUser[], filteredLanguages: string[] ) {
    console.log(filteredLanguages);
    var isIn = false;
    for(let k=0;k<filteredLanguages.length;k++) {
      for(let i=0;i<this.users.length;i++) {
        for(let j=0;j<this.users[i].languages.length;j++) {
          if(this.users[i].languages[j].language.toLowerCase() === filteredLanguages[k].toLowerCase()) {
            isIn=true;
          }
        }
        if(!isIn) {
          usersFiltered = usersFiltered.filter(u => u !== this.users[i])
        } else {
          isIn = false;
        }
      }
    }
    this.setupDataSource(usersFiltered);
  }

  sendMail (email: string) {
    var mail = 'mailto:' + email + '?subject=I found you on SkillMatrix&body=Send via SkillMatrix';
    window.open(mail);
  }
}

const joinWithCommaAndSpace = (stringArray: string[]) => stringArray.join(', ');
