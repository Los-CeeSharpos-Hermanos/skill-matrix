import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

export interface Categories {
  name: string;
  //position: number;
  //weight: number;
}

const ELEMENT_DATA: Categories[] = [
  {name: 'Zowsy'},
  {name: 'Bazinga'},
  {name: 'Iggily biggily'},
  {name: 'Gollygoops'},
  {name: 'Pasghetti'},
  {name: 'Woospiedoo'}
];


@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {
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
