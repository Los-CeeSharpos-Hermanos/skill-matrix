import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatRatedChipsComponent } from './mat-rated-chips.component';

describe('MatRatedChipsComponent', () => {
  let component: MatRatedChipsComponent;
  let fixture: ComponentFixture<MatRatedChipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MatRatedChipsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MatRatedChipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
