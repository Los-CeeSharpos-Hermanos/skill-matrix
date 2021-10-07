import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SkillService } from '../../services/skill.service';
import { Skill } from '../../skill';

@Component({
  selector: 'app-skill-edit',
  templateUrl: './skill-edit.component.html',
  styleUrls: ['./skill-edit.component.scss']
})
export class SkillEditComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private skillService: SkillService) { }

  private sub: Subscription;

  errorMessage: string;
  pageTitle: string;
  skill: Skill;
  skillForm: FormGroup;


  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;

        this.getSkill(id.toString());
      });
  }

  getSkill(id: string): void {
    this.skillService.getSkill(id)
      .subscribe({
        next: (skill: Skill) => this.displaySkill(skill),
        error: err => this.errorMessage = err
      });
  }

  displaySkill(skill: Skill): void {
    if (this.skillForm) {
      this.skillForm.reset();
    }

    this.skill = skill;

    if (this.skill.id === "0") {
      this.pageTitle = 'Add Skill';
    } else {
      this.pageTitle = `Edit Skill: ${this.skill.skillName}`;
    }

    this.skillForm.patchValue({
      skillName: this.skill.skillName,
      skillCategory: this.skill.skillName
    });
  }

}
