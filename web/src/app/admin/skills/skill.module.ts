import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { SharedModule } from 'src/app/shared/shared.module';
import { SkillDetailComponent } from './components/skill-detail/skill-detail.component';
import { SkillListComponent } from './components/skill-list/skill-list.component';
import { SkillData } from './skill-data';


@NgModule({
  declarations: [
    SkillListComponent,
    SkillDetailComponent
  ],
  imports: [
    SharedModule,
    InMemoryWebApiModule.forRoot(SkillData),
    RouterModule.forChild([
      { path: 'skillmatrix/skills', component: SkillListComponent },
      { path: 'skillmatrix/skills/:id', component: SkillDetailComponent },
      { path: 'skillmatrix/skills/:id/edit', component: SkillDetailComponent }
    ])
  ]
})
export class SkillModule { }


