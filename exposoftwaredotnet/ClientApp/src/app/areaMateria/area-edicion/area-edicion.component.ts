import { Component, OnInit } from '@angular/core';
import { Area } from '../models/area';
import { ActivatedRoute } from '@angular/router';
import { AreaService } from '../../services/area.service';

@Component({
  selector: 'app-area-edicion',
  templateUrl: './area-edicion.component.html',
  styleUrls: ['./area-edicion.component.css']
})
export class AreaEdicionComponent implements OnInit {

  area: Area;
  constructor(private areaService: AreaService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    this.area = new Area();
    const id = this.rutaActiva.snapshot.paramMap.get('idArea');
    this.areaService.getId(id).subscribe(a => {
      this.area = a;
      this.area != null ? alert('Se Consulta el area') : alert('Error al Consultar');
    });
  }

  update() {
    this.areaService.put(this.area).subscribe(a => {
      alert(a);
    });
  }

  delete() {
    this.areaService.delete(this.area.idArea).subscribe(a => {
      alert(a);
    });
  }

}
