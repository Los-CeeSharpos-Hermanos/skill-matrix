import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Skill } from '../skill';

@Injectable({
  providedIn: 'root'
})
export class SkillService {
  private skillsUrl = 'api/skills';

  constructor(private http: HttpClient) { }

  listSkills(): Observable<Skill[]> {
    const url = `${this.skillsUrl}`;
    console.log(url);
    return this.http.get<Skill[]>(url);
  }

  getSkill(id: string): Observable<Skill> {
    if (id == "0") {
      return of(this.initializeSkill());
    }

    const url = `${this.skillsUrl}/${id}`;
    return this.http.get<Skill>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteSkill(id: string): Observable<Skill> {
    if (id == "0") {
      console.log("invalid id");
    }

    const url = `${this.skillsUrl}/${id}`;
    return this.http.delete<Skill>(url)
      .pipe(
        tap(data => console.log('deleteSkill: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
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
      id: "0",
      skillCategory: null,
      skillName: null
    };
  }
}
