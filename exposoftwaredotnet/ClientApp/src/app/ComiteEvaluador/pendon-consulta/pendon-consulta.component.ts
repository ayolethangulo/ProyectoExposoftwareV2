import { Component, OnInit } from '@angular/core';
import { Pendon } from 'src/app/inscripcion/models/pendon';
import { PendonService } from 'src/app/services/pendon.service';

@Component({
  selector: 'app-pendon-consulta',
  templateUrl: './pendon-consulta.component.html',
  styleUrls: ['./pendon-consulta.component.css']
})
export class PendonConsultaComponent implements OnInit {

  searchText: string;
  pendons: Pendon[];
  constructor(private pendonService: PendonService) { }

  ngOnInit(): void {
    this.pendonService.get().subscribe(result => {
      this.pendons = result;
    });
  }

}
