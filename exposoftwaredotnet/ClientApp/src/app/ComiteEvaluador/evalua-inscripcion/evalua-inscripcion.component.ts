import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-evalua-inscripcion',
  templateUrl: './evalua-inscripcion.component.html',
  styleUrls: ['./evalua-inscripcion.component.css']
})
export class EvaluaInscripcionComponent implements OnInit {

  proyecto: Proyecto;
  constructor(private proyectoService: ProyectoService, private rutaActiva: ActivatedRoute,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.obtenerRuta();
  }
  obtenerRuta() {
    const id = this.rutaActiva.snapshot.params.idProyecto;
    this.proyectoService.getId(id).subscribe(p => {
      if (p != null) {
        this.proyecto = p;
      }
    });
  }

  update() {
    this.proyectoService.put(this.proyecto).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = 'Resultado Operación';
      messageBox.componentInstance.message = 'Actualizado correctamente!';
    });
  }

}
