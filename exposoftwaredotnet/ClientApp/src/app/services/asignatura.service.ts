import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient} from '@angular/common/http';
import { Asignatura } from '../areaMateria/models/asignatura';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class AsignaturaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
    { 
      this.baseUrl = baseUrl;
    }

    get(): Observable<Asignatura[]> {
      return this.http.get<Asignatura[]>(this.baseUrl + 'api/Asignatura')
      .pipe(
      catchError(this.handleErrorService.handleError<Asignatura[]>('Consulta Asignatura', null))
      );
    }
  
    post(asignatura: Asignatura): Observable<Asignatura> {
      return this.http.post<Asignatura>(this.baseUrl + 'api/Asignatura', asignatura)
      .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Asignatura>('Registrar Asignatura', null))
      );
    }

}
