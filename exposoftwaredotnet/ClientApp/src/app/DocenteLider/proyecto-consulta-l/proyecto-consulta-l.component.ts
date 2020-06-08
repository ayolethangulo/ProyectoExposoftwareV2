import { Component, OnInit } from '@angular/core';
import { Proyecto } from 'src/app/inscripcion/models/proyecto';
import { ProyectoService } from 'src/app/services/proyecto.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-proyecto-consulta-l',
  templateUrl: './proyecto-consulta-l.component.html',
  styleUrls: ['./proyecto-consulta-l.component.css']
})
export class ProyectoConsultaLComponent implements OnInit {

  id: string;
  proyecto: Proyecto;
  constructor(private proyectoService: ProyectoService, private modalService: NgbModal) { }

  ngOnInit(): void {
  }
  
  buscar() {
    this.proyectoService.getId(this.id).subscribe(result => {
      this.proyecto = result;
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
