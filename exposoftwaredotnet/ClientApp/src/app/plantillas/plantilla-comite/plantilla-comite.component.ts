import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-plantilla-comite',
  templateUrl: './plantilla-comite.component.html',
  styleUrls: ['./plantilla-comite.component.css']
})
export class PlantillaComiteComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
