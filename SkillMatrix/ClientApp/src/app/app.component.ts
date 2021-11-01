import {Component, HostBinding, Inject, OnInit, Renderer2} from '@angular/core';
import {DOCUMENT} from "@angular/common";
import {host} from "@angular-devkit/build-angular/src/test-utils";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  lightsOn = false;

  title = "web";

  switchTheme(mode: boolean)
  {
    this.lightsOn = mode;
    const hostClass = this.lightsOn ? 'light-theme' : 'dark-theme';
    this.rederer.setAttribute(this.document.body, 'class', hostClass);
  }

  constructor(@Inject(DOCUMENT) private document: Document,
              private rederer: Renderer2) {
  }

  ngOnInit()
  {
    this.rederer.setAttribute(this.document.body, 'class', 'dark-theme');
  }

}

