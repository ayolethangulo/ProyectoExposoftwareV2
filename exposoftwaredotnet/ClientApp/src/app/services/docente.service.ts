import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Docente } from '../inscripcion/models/docente';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DocenteService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Docente[]> {
    return this.http.get<Docente[]>(this.baseUrl + 'api/Docente')
      .pipe(
        catchError(this.handleErrorService.handleError<Docente[]>('Consulta Docente', null))
      );
  }

  post(docente: Docente): Observable<Docente> {
    return this.http.post<Docente>(this.baseUrl + 'api/Docente', docente)
      .pipe(
        tap(_ => this.handleErrorService.log('Docente registrado.')),
        catchError(this.handleErrorService.handleError<Docente>('Registrar Docente', null))
      );
  }

  getId(id: string): Observable<Docente> {
    const url = `${this.baseUrl + 'api/Docente'}/${id}`;
    return this.http.get<Docente>(url, httpOptions)
      .pipe(
        catchError(this.handleErrorService.handleError<Docente>('Docente no Registrado', null))
      );
  }

}
