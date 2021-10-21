import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { RoutingService } from 'src/app/shared/services/routing.service';
import { SnackBarService } from 'src/app/shared/services/snack-bar.service';
import { SkillService } from '../../services/skill.service';
import { AddSkill, Skill } from '../../skill';
import { ISkillCategoryDropdown } from '../../skillCategory';

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
  skillCategories: ISkillCategoryDropdown[];

  skillForm = this.fb.group({
    skillName: ['', Validators.required],
    skillCategory: ['', Validators.required],
  });


  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = params.get('id')!;
        this.getSkillCategories();
        console.log(JSON.stringify(this.skillCategories));
        this.getSkill(id);

      });
  }

  getSkillCategories() {
    this.skillService.listSkillCategories()
      .subscribe({
        next: (skillCategories: ISkillCategoryDropdown[]) => {
          this.skillCategories = skillCategories;
        },
        error: err => {
          this.errorMessage = err;
          console.log(err);
        }
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
        let skillCategory = this.skillForm.value;
        console.log(JSON.stringify(skillCategory));
        const editSkill = { ...this.skill, ...this.skillForm.value };
        if (editSkill.id == 0) {

          this.skillService.createSkill({
            skillName: editSkill.skillName,
            skillCategoryId: editSkill.skillCategory.skillCategoryId
          } as AddSkill)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.onSaveFail(err)
            });

        } else {
          console.log(" updateSkill");

          this.skillService.updateSkill(editSkill)
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


