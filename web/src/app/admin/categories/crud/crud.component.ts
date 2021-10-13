import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

export interface Categories {
  name: string;
  number: number;
  //position: number;
  //weight: number;
}

const ELEMENT_DATA: Categories[] = [
  {name: 'Frontend', number: 5},
  {name: 'Backend', number: 3},
  {name: 'Databases', number: 15},
  {name: 'Sports', number: 8},
  {name: 'Soft Skills', number: 7},
  {name: 'Hobbies', number: 12}
];

@Component({
  selector: 'categories-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})

export class CRUDComponent implements OnInit {

  there = "skillmatrix/categories/add";


  displayedColumns: string[] = ['name', 'number', 'buttons'];
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
