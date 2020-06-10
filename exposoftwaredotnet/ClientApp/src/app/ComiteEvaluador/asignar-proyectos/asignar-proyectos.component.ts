import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';

@Component({
  selector: 'app-asignar-proyectos',
  templateUrl: './asignar-proyectos.component.html',
  styleUrls: ['./asignar-proyectos.component.css']
})
export class AsignarProyectosComponent implements OnInit {

  searchText: string;
  proyectos: Proyecto[];
  constructor(private proyectoService: ProyectoService) { }

  ngOnInit(): void {
    this.proyectoService.get().subscribe(result => {
      this.proyectos = result;
    });
  }

}
