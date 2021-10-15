import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: 'add-category.component.html',
  styleUrls: ['add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {

  constructor(private router: Router) { }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  ngOnInit(): void {
  }

}
