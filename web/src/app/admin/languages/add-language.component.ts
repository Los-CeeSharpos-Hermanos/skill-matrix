import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-language',
  templateUrl: './add-language.component.html',
  styleUrls: ['./add-language.component.scss']
})
export class AddLanguageComponent implements OnInit {

  constructor() { }

  clickAdd(): void {
    //send input to database server;
    console.log("send input to database server");
    //get notification from server
    //if saved show confirmation message
    //if existing show error
  }

  ngOnInit(): void {
  }

}
