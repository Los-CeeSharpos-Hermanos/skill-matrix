import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-languagelist',
  templateUrl: './languagelist.component.html',
  styleUrls: ['./languagelist.component.scss']
})
export class LanguagelistComponent implements OnInit {

  languages: string[] = [
    "german", "english", "spanish", "french" 
  ]; //get list of languages from database here

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  goTo(path: string) {
    this.router.navigate([path]);
  }

}
