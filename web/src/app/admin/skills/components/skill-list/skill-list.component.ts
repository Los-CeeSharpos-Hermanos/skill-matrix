import { Component, OnInit } from '@angular/core';
import { SkillService } from '../../services/skill.service';
import { Skill } from '../../skill';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.scss']
})
export class SkillListComponent implements OnInit {
  constructor(private skillService: SkillService) { }
  pageTitle = "Skills List";
  errorMessage = '';
  skills: Skill[];


  ngOnInit(): void {
    this.skillService.listSkills().subscribe({
      next: skills => {
        this.skills = skills;
        console.log(skills);
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }

}
