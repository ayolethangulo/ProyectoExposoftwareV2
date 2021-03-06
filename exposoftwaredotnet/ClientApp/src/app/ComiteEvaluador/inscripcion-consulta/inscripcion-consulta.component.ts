import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';
import { SignalRProyectoService } from 'src/app/services/signal-rproyecto.service';

@Component({
  selector: 'app-inscripcion-consulta',
  templateUrl: './inscripcion-consulta.component.html',
  styleUrls: ['./inscripcion-consulta.component.css']
})
export class InscripcionConsultaComponent implements OnInit {

  searchText: string;
  proyectos: Proyecto[];
  constructor(private proyectoService: ProyectoService, private signalRProyecto: SignalRProyectoService) { }

  ngOnInit(): void {
    this.proyectoService.get().subscribe(result => {
      this.proyectos = result;
    });
    this.signalRProyecto.signalReceived.subscribe((proyecto: Proyecto) => {
      this.proyectos.push(proyecto);
    });
  }

}
