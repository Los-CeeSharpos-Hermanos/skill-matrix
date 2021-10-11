import { Component, OnInit } from '@angular/core';
import { RoutingService } from '../../services/routing/routing.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  constructor(private routingService: RoutingService) { }

  ngOnInit(): void {
  }

  goTo(path: string) {
    this.routingService.goTo(path);
  }

  title = 'Skill-Matrix by Andrei-Nicolae Ene, Conrado Goncalves, Marten Maiburg and Nico Wisotzki';
}
