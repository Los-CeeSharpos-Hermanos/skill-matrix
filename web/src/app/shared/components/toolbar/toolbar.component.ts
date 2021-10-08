import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  goTo(path: string) {
    this.router.navigate([path]);
  }
  title = 'Skill-Matrix by Andrei-Nicolae Ene, Conrado Goncalves, Marten Maiburg and Nico Wisotzki';
}
