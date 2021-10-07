import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { MaterialsModule } from 'src/app/shared/materials/materials.module';
import { SkillDetailComponent } from './components/skill-detail/skill-detail.component';
import { SkillListComponent } from './components/skill-list/skill-list.component';
import { SkillData } from './skill-data';


@NgModule({
  declarations: [
    SkillListComponent,
    SkillDetailComponent
  ],
  imports: [
    InMemoryWebApiModule.forRoot(SkillData),
    MaterialsModule,
    CommonModule,
    RouterModule.forChild([
      { path: 'skillmatrix/admin/skills', component: SkillListComponent },
      { path: 'skillmatrix/admin/skills/:id', component: SkillDetailComponent },
      { path: 'skillmatrix/admin/skills/:id/edit', component: SkillDetailComponent }
    ])
  ]
})
export class SkillModule { }


