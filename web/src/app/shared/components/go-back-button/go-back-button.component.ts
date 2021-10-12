import { Component } from '@angular/core';
import { RoutingService } from '../../services/routing.service';

@Component({
  selector: 'app-go-back-button',
  templateUrl: './go-back-button.component.html',
  styleUrls: ['./go-back-button.component.scss']
})
export class GoBackButtonComponent {
  constructor(private routingService: RoutingService) { }

  goBack(): void {
    this.routingService.goBack();
  }

}
