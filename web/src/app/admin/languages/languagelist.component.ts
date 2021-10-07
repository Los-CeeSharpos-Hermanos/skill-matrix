import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-languagelist',
  templateUrl: './languagelist.component.html',
  styleUrls: ['./languagelist.component.scss']
})
export class LanguagelistComponent implements OnInit {

  languages: string[] = [
    "german", "english", "spanish", "french" 
  ]; //get list of languages from database here

  constructor() { }

  ngOnInit(): void {
  }

}
