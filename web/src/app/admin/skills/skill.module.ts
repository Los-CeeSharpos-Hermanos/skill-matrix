import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SkillDetailComponent } from './skill-detail/skill-detail.component';
import { SkillListComponent } from './skill-list/skill-list.component';

@NgModule({
  declarations: [
    SkillListComponent,
    SkillDetailComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'skillmatrix/admin/skills', component: SkillListComponent },
      { path: 'skillmatrix/admin/skills/:id', component: SkillDetailComponent },
      { path: 'skillmatrix/admin/skills/:id/edit', component: SkillDetailComponent }
    ])
  ]
})
export class SkillModule { }
