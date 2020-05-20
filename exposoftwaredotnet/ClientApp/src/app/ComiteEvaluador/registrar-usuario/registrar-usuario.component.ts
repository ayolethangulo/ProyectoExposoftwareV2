import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  usuario: Usuario;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {

    this.usuario = new Usuario();

  }

  add() {

    this.usuarioService.post(this.usuario).subscribe(p => {

      if (p != null) {

        this.usuario = p;

      }

    });

  }

}
