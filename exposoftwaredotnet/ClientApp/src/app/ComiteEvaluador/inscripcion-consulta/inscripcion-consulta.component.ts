import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';

@Component({
  selector: 'app-inscripcion-consulta',
  templateUrl: './inscripcion-consulta.component.html',
  styleUrls: ['./inscripcion-consulta.component.css']
})
export class InscripcionConsultaComponent implements OnInit {

  searchText: string;
  proyectos: Proyecto[];
  constructor(private proyectoService: ProyectoService) { }

  ngOnInit(): void {
    this.proyectoService.get().subscribe(result => {
      this.proyectos = result;
    });
  }

}
