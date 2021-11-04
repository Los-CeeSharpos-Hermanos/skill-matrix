import { Component, OnInit } from '@angular/core';
import { IUser } from '../user';

@Component({
  selector: 'app-user-show',
  templateUrl: './user-show.component.html',
  styleUrls: ['./user-show.component.scss']
})
export class UserShowComponent implements OnInit {

  public user: IUser = {
    id: 100,
    surName: "Person",
    firstName: "Test",
    telephone: "0123456789",
    email: "test.person@gmail.com",
    jobTitle: "Developer",
    location: "Leipzig",
    department: "Sales",
    team: "A-Team",
    skills: [{skillName: "C#", skillCategory: "Coding", rating: 1}, {skillName: "Java", skillCategory: "Coding", rating: 3}],
    languages: [{language: "german", rating: 2}, {language: "english", rating: 3}],
    imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"}
  constructor() { }

  ngOnInit(): void {
  }

}
