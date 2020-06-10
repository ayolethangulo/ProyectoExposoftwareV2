import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ItemsRubricaService } from 'src/app/services/items-rubrica.service';
import { ItemsRubrica } from 'src/app/areaMateria/models/items-rubrica';
import { DescripcionC } from 'src/app/areaMateria/models/descripcion-c';
import { DescripcionCService } from 'src/app/services/descripcion-c.service';

@Component({
  selector: 'app-registrar-calificacion',
  templateUrl: './registrar-calificacion.component.html',
  styleUrls: ['./registrar-calificacion.component.css']
})
export class RegistrarCalificacionComponent implements OnInit {

  itemsRubricas: ItemsRubrica[];
  valor: string;
  descripcionC: DescripcionC;
  descripciones: DescripcionC[];
  constructor(private rutaActiva: ActivatedRoute, private itemsRubricaService: ItemsRubricaService,
    private descripcionCService: DescripcionCService) { }

  ngOnInit(): void {
    this.obtenerRuta();
    this.valor = '';
  }
  obtenerRuta() {
    const idP = this.rutaActiva.snapshot.params.idProyecto;
    const idR = this.rutaActiva.snapshot.params.idRubrica;
    this.itemsRubricaService.get(idR).subscribe(result => {
      this.itemsRubricas = result;
      for (let index = 0; index < this.itemsRubricas.length; index++) {
        this.descripcionC = new DescripcionC();
        this.descripcionC.idProyecto = idP;
        this.descripcionC.descripcion = this.itemsRubricas[index].descripcion;
        this.descripcionCService.post(this.descripcionC).subscribe(ir => {
          if (ir != null) {
          this.descripcionC = ir;
          }
        });
      }
      this.cargarDescripcion(idP);
    });
  }
  cargarDescripcion(proyecto: number) {
    this.descripcionCService.get(proyecto).subscribe(result => {
      this.descripciones = result;
    });
  }
}
