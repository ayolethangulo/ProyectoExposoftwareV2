import { Component, OnInit } from '@angular/core';
import { Docente } from 'src/app/inscripcion/models/docente';
import { DocenteService } from 'src/app/services/docente.service';

@Component({
  selector: 'app-consultar-docentes',
  templateUrl: './consultar-docentes.component.html',
  styleUrls: ['./consultar-docentes.component.css']
})
export class ConsultarDocentesComponent implements OnInit {

  searchText: string;
  docentes: Docente[];
  constructor(private docenteService: DocenteService) { }

  ngOnInit(): void {
    this.docenteService.get().subscribe(result => {
      this.docentes = result;
    });
  }

}
