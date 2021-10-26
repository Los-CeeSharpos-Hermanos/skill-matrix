import { Component, Input } from '@angular/core';
import { RoutingService } from '../../services/routing.service';

@Component({
  selector: 'app-add-button',
  templateUrl: './add-button.component.html',
  styleUrls: ['./add-button.component.scss']
})
export class AddButtonComponent {

  @Input() goToPath = '';

  constructor(private routingService: RoutingService) { }

  goTo(): void {
    this.routingService.goTo(this.goToPath);
  }
}
