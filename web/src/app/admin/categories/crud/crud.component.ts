import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

export interface Categories {
  name: string;
  //position: number;
  //weight: number;
}

const ELEMENT_DATA: Categories[] = [
  {name: 'Frontend'},
  {name: 'Backend'},
  {name: 'Databases'},
  {name: 'Sports'},
  {name: 'Soft Skills'},
  {name: 'Hobbies'}
];

@Component({
  selector: 'categories-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})

export class CRUDComponent implements OnInit {

  there = "skillmatrix/categories/add";


  displayedColumns: string[] = ['name', 'weight', 'symbol'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(private router: Router) { }

  goTo(path: string) {
    this.router.navigate([path]);
  }

  ngOnInit(): void {
  }

}
