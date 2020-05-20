import { Component, OnInit } from '@angular/core';
import { DocenteService } from 'src/app/services/docente.service';
import { Docente } from 'src/app/inscripcion/models/docente';

@Component({
  selector: 'app-registrar-docentes',
  templateUrl: './registrar-docentes.component.html',
  styleUrls: ['./registrar-docentes.component.css']
})
export class RegistrarDocentesComponent implements OnInit {

  docente: Docente;

  constructor(private docenteService: DocenteService) { }

  ngOnInit() {

    this.docente = new Docente();

  }

  add() {

    this.docenteService.post(this.docente).subscribe(p => {

      if (p != null) {
        this.docente = p;

      }

    });

  }
}
