import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../../category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private baseUrl = 'api/categories';
  headers = new HttpHeaders({ 'Content-type': 'application/json' });

  constructor(private http: HttpClient) { }

  listCategories(): Observable<ICategory[]> {
    const url = `${this.baseUrl}`;
    console.log(url);
    return this.http.get<ICategory[]>(url);
  }
}
