import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav, demo-accordion-animation',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor() { }

  ngOnInit() {
  }

}
