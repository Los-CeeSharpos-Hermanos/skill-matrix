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

  clickAdd( surName: string,firstName: string, email: string, department: string, team: string, skill: string, language: string, imageUrl: string): void
  {
    let id : number = 0;
    this.isThere = false;
    for(let user of this.users) {
      if(user.firstName == firstName && user.surName == surName) {
        this.isThere = true; break;
      }
    }
    if(!this.isThere) {
      if(firstName!="" && surName!="") {
        this.users.push({ id , surName, firstName, email, department, team, skill, language, imageUrl });
        alert('New Language added');
      } else {
        alert('Please fill every field')
      }
    } else {
      alert('Some Properties of your language already exist!');
    }
    for(let user of this.users) {
      console.log(user.firstName);
    }
    //get notification from server
    //if saved show confirmation message
    //if existing show error
  }
  }




