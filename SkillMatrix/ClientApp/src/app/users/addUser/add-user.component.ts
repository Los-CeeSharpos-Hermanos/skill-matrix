import { Component, OnInit } from '@angular/core';
import { IUser } from '../user';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  constructor() { }
  isThere: Boolean = false;
  users: IUser[] = [];

  ngOnInit(): void {
  }

  //Steps to add a user
  //get form data
  //use the service to generate a request to add a new user
  //get notification from server
  //if saved show confirmation message
  //if existing show error

}




