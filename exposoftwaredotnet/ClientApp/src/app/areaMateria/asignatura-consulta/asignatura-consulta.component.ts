import { Component, OnInit } from '@angular/core';
import { Asignatura } from '../models/asignatura';
import { AsignaturaService } from '../../services/asignatura.service';


@Component({
  selector: 'app-asignatura-consulta',
  templateUrl: './asignatura-consulta.component.html',
  styleUrls: ['./asignatura-consulta.component.css']
})
export class AsignaturaConsultaComponent implements OnInit {

  searchText: string;
  asignaturas: Asignatura[];
  constructor(private asignaturaService: AsignaturaService) { }

  ngOnInit(): void {
    this.asignaturaService.get().subscribe(result => {
      this.asignaturas = result;
    });
  }

}
