import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Usuario } from '../ComiteEvaluador/models/usuario';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
      this.baseUrl = baseUrl;
    }

    get(): Observable<Usuario[]> {
      return this.http.get<Usuario[]>(this.baseUrl + 'api/Usuario')
      .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Usuario[]>('Consulta Usuario', null))
      );
    }
    post(usuario: Usuario): Observable<Usuario> {
      return this.http.post<Usuario>(this.baseUrl + 'api/Usuario', usuario)
      .pipe(
      tap(_ => this.handleErrorService.log('Usuario registrado')),
      catchError(this.handleErrorService.handleError<Usuario>('Registrar Usuario', null))
      );
    }
}
