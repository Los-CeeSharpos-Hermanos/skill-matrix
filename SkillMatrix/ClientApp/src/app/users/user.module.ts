import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ProfileComponent } from '../profile/profile.component';
import { SharedModule } from '../shared/shared.module';
import { UserListComponent } from './userList/user-list.component';


@NgModule({
  declarations: [
    UserListComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'skillmatrix/users', component: UserListComponent },
      { path: 'skillmatrix/users/:id', component: ProfileComponent },
      { path: 'skillmatrix/users/:id/edit', component: ProfileComponent }
    ]),
    SharedModule,
    FormsModule,
  ]
})
export class UserModule { }
