import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing/routing.service';
import { SkillService } from '../../services/skill.service';
import { Skill } from '../../skill';

interface SkillCategory {
  id: number,
  skillCategoryName: string;
}

const fakeSkillCategories: SkillCategory[] = [
  { id: 1, skillCategoryName: "Technical Skill" },
  { id: 2, skillCategoryName: "Soft Skill" }
];

@Component({
  selector: 'app-skill-edit',
  templateUrl: './skill-edit.component.html',
  styleUrls: ['./skill-edit.component.scss']
})
export class SkillEditComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private routingService: RoutingService,
    private skillService: SkillService) { }

  private sub: Subscription;

  errorMessage: string;
  pageTitle: string;
  skill: Skill;
  skillCategories: SkillCategory[];

  skillForm = this.fb.group({
    skillName: ['', Validators.required],
    skillCategory: ['', Validators.required],
  });


  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.getSkillCategories();
        this.getSkill(id);

      });
  }

  getSkillCategories() {
    this.skillCategories = fakeSkillCategories;
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

    if (this.skill.id === 0) {
      this.pageTitle = 'Add Skill';
    } else {
      this.pageTitle = `Edit Skill: ${this.skill.skillName}`;
    }

    this.skillForm.patchValue({
      skillName: this.skill.skillName,
      skillCategory: this.skill.skillCategory
    });
  }


  editSkill(skill: Skill): void {
    this.skillService.updateSkill(skill)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
  }

  saveSkill(): void {
    if (this.skillForm.valid) {

      if (this.skillForm.dirty) {
        const s = { ...this.skill, ...this.skillForm.value };

        if (s.id == 0) {

          this.skillService.createSkill(s)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });

        } else {
          console.log(" updateSkill");

          this.skillService.updateSkill(s)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => { this.errorMessage = err; console.log(this.errorMessage); }
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct validation errors";
      console.log(this.errorMessage);
    }
  }

  onSaveComplete() {
    this.skillForm.reset();
    this.routingService.goTo('/skillmatrix/skills');
  }
}


