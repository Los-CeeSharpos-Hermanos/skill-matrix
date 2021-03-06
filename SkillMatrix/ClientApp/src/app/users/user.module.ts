import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { UserEditComponent } from './user-edit/user-edit.component';
import { UserShowComponent } from './user-show/user-show.component';
import { UserListComponent } from './userList/user-list.component';


@NgModule({
  declarations: [
    UserListComponent,
    UserEditComponent,
    UserShowComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'skillmatrix/users', component: UserListComponent },
      { path: 'skillmatrix/users/profile', component: UserShowComponent },
      { path: 'skillmatrix/users/:id/add', component: UserEditComponent, pathMatch: 'full' },
      { path: 'skillmatrix/users/:id/edit', component: UserEditComponent, pathMatch: 'full' }
    ]),
    SharedModule,
    FormsModule,
  ]
})
export class UserModule { }
