import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { DescripcionC } from '../areaMateria/models/descripcion-c';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DescripcionCService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(idProyecto: number): Observable<DescripcionC[]> {
    const url = `${this.baseUrl + 'api/DescripcionC'}/${idProyecto}`;
    return this.http.get<DescripcionC[]>(url, httpOptions)
      .pipe(
        catchError(this.handleErrorService.handleError<DescripcionC[]>('Consulta resultados', null))
      );
  }

  post(descripcion: DescripcionC): Observable<DescripcionC> {
    return this.http.post<DescripcionC>(this.baseUrl + 'api/DescripcionC', descripcion)
      .pipe(
        catchError(this.handleErrorService.handleError<DescripcionC>('Registrar resultados', null))
      );
  }

  put(descripcion: DescripcionC): Observable<any> {
    const url = `${this.baseUrl}api/DescripcionC/${descripcion.idDescripcion}`;
    return this.http.put(url, descripcion, httpOptions)
    .pipe(
      tap(_ => this.handleErrorService.log('Se ha actualizado correctamente!')),
      catchError(this.handleErrorService.handleError<any>('Editar resultados'))
    );
  }
  delete(descripcion: DescripcionC| string): Observable<string> {
    const id = typeof descripcion === 'string' ? descripcion : descripcion.idDescripcion;
    return this.http.delete<string>(this.baseUrl + 'api/DescripcionC/' + id)
    .pipe(
      tap(_ => this.handleErrorService.log('Se ha eliminado correctamente!')),
      catchError(this.handleErrorService.handleError<string>('Elimiar resultados', null))
    );
  }
}
