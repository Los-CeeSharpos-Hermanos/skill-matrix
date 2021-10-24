import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
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
    private skillService: SkillService,
    private snackBarService: SnackBarService) { }

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
      this.pageTitle = 'Add a new Skill';
    } else {
      this.pageTitle = `Editing Skill: ${this.skill.skillName}`;
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
              error: err => this.onSaveFail(err)
            });

        } else {
          console.log(" updateSkill");

          this.skillService.updateSkill(s)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
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

  deleteSkill(): void {
    if (this.skill.id === 0) {
      this.onSaveComplete();
    } else {
      if (confirm(`Àre you sure you want to delete the skill: ${this.skill.skillName}`)) {
        this.skillService.deleteSkill(this.skill.id)
          .subscribe({
            next: () => this.onSaveComplete("Skill deleted successfully!"),
            error: err => this.onSaveFail(err)
          });

      }
    }
  }

  onSaveComplete(message: string = "Skill saved successfully!") {
    this.skillForm.reset();
    this.snackBarService.success(message);
    this.routingService.goTo('/skillmatrix/skills');
  }

  onSaveFail(err: any, message: string = "An error has occured!") {

    this.errorMessage = err; console.log(this.errorMessage);
    this.snackBarService.warn(message);
  }


}


