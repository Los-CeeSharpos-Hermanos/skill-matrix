import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { UserListComponent } from './userList/user-list.component';
import { AddUserComponent } from './addUser/add-user.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UserListComponent,
    AddUserComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'skillmatrix/members', component: UserListComponent },
      { path: '', component: UserListComponent },
      { path: 'skillmatrix/members/addUser', component: AddUserComponent },

    ]),
    SharedModule,
    FormsModule,
  ]
})
export class UserModule { }
