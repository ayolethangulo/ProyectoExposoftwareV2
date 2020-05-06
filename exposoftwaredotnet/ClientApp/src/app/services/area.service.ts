import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Area } from '../areaMateria/models/area';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Area[]> {
    return this.http.get<Area[]>(this.baseUrl + 'api/Area')
      .pipe(
        catchError(this.handleErrorService.handleError<Area[]>('Consulta Area', null))
      );
  }
  post(area: Area): Observable<Area> {
    return this.http.post<Area>(this.baseUrl + 'api/Area', area)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Area>('Registrar Area', null))
      );
  }

}
