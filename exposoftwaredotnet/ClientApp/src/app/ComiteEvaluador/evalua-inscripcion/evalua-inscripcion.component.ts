import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';

@Component({
  selector: 'app-evalua-inscripcion',
  templateUrl: './evalua-inscripcion.component.html',
  styleUrls: ['./evalua-inscripcion.component.css']
})
export class EvaluaInscripcionComponent implements OnInit {

  proyecto:Proyecto[];

  constructor(private proyectoService: ProyectoService) { }
  
  ngOnInit() {
  
  this.proyectoService.get().subscribe(result => {
  
  this.proyecto = result;
  
  });

  }
}
