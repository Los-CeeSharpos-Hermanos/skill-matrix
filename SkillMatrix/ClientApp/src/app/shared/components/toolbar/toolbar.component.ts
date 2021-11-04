import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { RoutingService } from '../../services/routing.service';
import {MatSlideToggleChange} from "@angular/material/slide-toggle";

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  @Output()

  readonly darkModeSwitched = new EventEmitter<boolean>();

  constructor(private routingService: RoutingService) { }

  ngOnInit(): void {
  }

  goTo(path: string) {
    this.routingService.goTo(path);
  }

  onDarkModeSwitched({checked}: MatSlideToggleChange)
  {
    this.darkModeSwitched.emit(checked);
  }

  title = 'Skill-Matrix by Andrei-Nicolae Ene, Conrado Goncalves, Marten Maiburg and Nico Wisotzki';
}
