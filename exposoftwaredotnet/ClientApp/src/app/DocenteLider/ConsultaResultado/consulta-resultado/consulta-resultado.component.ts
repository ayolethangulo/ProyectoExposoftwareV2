import { Component, OnInit } from '@angular/core';
import { Calificacion } from 'src/app/areaMateria/models/calificacion';
import { DescripcionCalificacion } from 'src/app/areaMateria/models/descripcion-calificacion';
import { ItemsRubrica } from 'src/app/areaMateria/models/items-rubrica';
import { CalificacionService } from 'src/app/services/calificacion.service';
import { DescripcionCService } from 'src/app/services/descripcion-c.service';
import { ItemsRubricaService } from 'src/app/services/items-rubrica.service';

@Component({
  selector: 'app-consulta-resultado',
  templateUrl: './consulta-resultado.component.html',
  styleUrls: ['./consulta-resultado.component.css']
})
export class ConsultaResultadoComponent implements OnInit {

  itemsRubrica: ItemsRubrica[];
  descripcion: DescripcionCalificacion;
  calificacion: Calificacion;
  idRubrica: string;
  idProyecto: number;
  valor1: number;
  valor2: number;
  valor3: number;
  total: number;

  constructor(private calificacionService: CalificacionService, private itemsRubricaService: ItemsRubricaService,
    private descripcionCService: DescripcionCService) { }

  ngOnInit(): void {
  }

  buscar() {
    this.calificacionService.getId(this.idProyecto).subscribe(c => {
      this.calificacion = c;
      alert(this.calificacion.idProyecto);
      this.cargarItem(this.calificacion.idRubrica, this.calificacion.idProyecto);
    });
  }
  cargarItem(rubrica: string, idProyecto: number) {
    this.itemsRubricaService.get(rubrica).subscribe(result => {
      this.itemsRubrica = result;
      this.cargarPuntaje(idProyecto);
    });
  }

  cargarPuntaje(idProyecto: number) {
    this.descripcionCService.getId(idProyecto).subscribe(p => {
      this.descripcion = p;
      this.valor1 = p.p1;
      this.valor2 = p.p2;
      this.valor3 = p.p3;
      this.total = p.valor;
    });
  }

}
