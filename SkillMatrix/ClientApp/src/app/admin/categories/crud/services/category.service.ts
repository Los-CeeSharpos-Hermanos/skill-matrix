import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ICategory } from '../../category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private baseUrl = 'api/categories';
  headers = new HttpHeaders({ 'Content-type': 'application/json' });

  constructor(private http: HttpClient) { }

  createCategory(category: ICategory)
  {
    const url = `${this.baseUrl}`;
    category.id = 0;
    return this.http.post<ICategory>(url, category, { headers: this.headers });
  }

  readCategories(): Observable<ICategory[]> {
    const url = `${this.baseUrl}`;
    console.log(url);
    return this.http.get<ICategory[]>(url);
  }

  readCategory(id: string): Observable<ICategory> {
    if (id == "0") {
      return of(this.initializeCategory());
    }

    const url = `${this.baseUrl}/${id}`;
    console.log(url);
    return this.http.get<ICategory>(url);
  }

  updateCategory(category: ICategory): Observable<ICategory> {
    const url = `${this.baseUrl}/${category.id}}`;
    return this.http.put<ICategory>(url, category, { headers: this.headers });
  }

  deleteCategory(id: number): Observable<{}> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<ICategory>(url, { headers: this.headers });
  }

  private initializeCategory(): ICategory {
    return {
      id: 0,
      name: '',
    };
  }
}
