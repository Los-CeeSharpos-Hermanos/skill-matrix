import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { SharedModule } from 'src/app/shared/shared.module';
import { SkillDetailComponent } from './components/skill-detail/skill-detail.component';
import { SkillEditComponent } from './components/skill-edit/skill-edit.component';
import { SkillListComponent } from './components/skill-list/skill-list.component';
import { SkillData } from './skill-data';


@NgModule({
  declarations: [
    SkillListComponent,
    SkillDetailComponent,
    SkillEditComponent
  ],
  imports: [
    SharedModule,
    FormsModule,
    InMemoryWebApiModule.forRoot(SkillData),
    RouterModule.forChild([
      { path: 'skillmatrix/skills', component: SkillListComponent },
      { path: 'skillmatrix/skills/:id', component: SkillEditComponent },
      { path: 'skillmatrix/skills/:id/edit', component: SkillEditComponent }
    ])
  ]
})
export class SkillModule { }


