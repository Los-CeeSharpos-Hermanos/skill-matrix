import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { RoutingService } from 'src/app/shared/services/routing/routing.service';
import { SkillService } from './services/skill.service';
import { Skill } from './skill';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.scss']
})
export class SkillListComponent implements OnInit {

  constructor(private skillService: SkillService, private routingService: RoutingService) { }

  displayedColumns: string[] = ['name', 'category', 'action'];

  pageTitle = "Skills List";
  errorMessage = '';
  skills: Skill[];
  dataSource: MatTableDataSource<Skill>;

  ngOnInit(): void {
    this.loadSkills();
  }

  deleteSkill(id: number): void {
    if (id === 0) {
      alert("Invalid id");
    } else {
      console.log(id);
      if (confirm(`Àre you sure you want to delete this skill?`)) {
        this.skillService.deleteSkill(id)
          .subscribe({
            next: () => this.loadSkills(),
            error: err => { this.errorMessage = err; console.log(this.errorMessage); }
          });

      }
    }
  }

  goToAddSkill() {
    this.routingService.goTo('skillmatrix/skills/0/edit');
  }

  goToEditSkill(id: number) {
    this.routingService.goTo(`skillmatrix/skills/${id}/edit`);
  }

  private loadSkills() {
    this.skillService.listSkills().subscribe({
      next: skills => {
        this.skills = skills;
        this.dataSource = new MatTableDataSource(skills);
      },
      error: err => { this.errorMessage = err; console.log(err); }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
