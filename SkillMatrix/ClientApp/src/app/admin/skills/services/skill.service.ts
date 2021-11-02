import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { AddSkill, Skill } from '../skill';
import { ISkillCategoryDropdown } from '../skillCategory';

const baseUrl = 'api/skills';
const baseUri = `${environment.apiEndpoint}/${baseUrl}`;

const skillCategoryBaseUrl = 'api/SkillCategories';
const skillCategoryDropdownPath = 'dropdown-skill-categories';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  headers = new HttpHeaders({ 'Content-type': 'application/json' });

  constructor(private http: HttpClient) { }

  //HERE
  //HERE
  //HERE
  //HERE
  //HERE
  //HERE
  //HERE

  listSkills(): Observable<Skill[]> {
    return this.http.get<Skill[]>(`${baseUri}`);
  }

  listSkillCategories(): Observable<ISkillCategoryDropdown[]> {
    return this.http.get<ISkillCategoryDropdown[]>(`${environment.apiEndpoint}/${skillCategoryBaseUrl}/${skillCategoryDropdownPath}`);
  }

  getSkill(id: string): Observable<Skill> {
    if (id == "0") {
      return of(this.initializeSkill());
    }

    const url = `${environment.apiEndpoint}/${baseUrl}/${id}`;
    return this.http.get<Skill>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  createSkill(skill: AddSkill) {
    return this.http.post<Skill>(baseUri, skill, { headers: this.headers });
  }

  updateSkill(skill: AddSkill): Observable<Skill> {
    const url = `${baseUri}/${skill.id}`;
    return this.http.put<Skill>(url, skill, { headers: this.headers });
  }

  deleteSkill(id: number): Observable<{}> {
    if (id === 0) {
      console.log("invalid id");
    }

    const url = `${baseUri}/${id}`;
    return this.http.delete<Skill>(url, { headers: this.headers });
  }

  private handleError(err: any): Observable<never> {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Errorcode ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeSkill(): Skill {
    return {
      id: 0,
      skillCategoryName: null,
      skillName: null,
      skillCategoryId: null
    };
  }
}
