import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatSlideToggleChange } from "@angular/material/slide-toggle";
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'src/app/auth/authentication.service';
import { RoutingService } from '../../services/routing.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
  checkAuth$: Subscription;
  isLoggedIn: boolean;

  @Output()

  readonly darkModeSwitched = new EventEmitter<boolean>();

  constructor(private routingService: RoutingService, private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.authenticationService.isLoggedUser.subscribe(x => this.isLoggedIn = x);
  }

  ngOnDestroy() {
    this.authenticationService.isLoggedUser.unsubscribe();
  }

  goTo(path: string) {
    this.routingService.goTo(path);
  }

  goToHomePage() {
    this.authenticationService.isLoggedUser.subscribe(x => this.isLoggedIn = x);

    if (this.isLoggedIn) {
      this.routingService.goTo('skillmatrix/users');
    } else {
      this.routingService.goTo('/');
    }
  }


  logout() {
    this.authenticationService.logout();
    this.routingService.goTo('/');
  }

  onDarkModeSwitched({ checked }: MatSlideToggleChange) {
    this.darkModeSwitched.emit(checked);
  }

  title = 'Skill-Matrix by Andrei-Nicolae Ene, Conrado Goncalves, Marten Maiburg and Nico Wisotzki';
}
