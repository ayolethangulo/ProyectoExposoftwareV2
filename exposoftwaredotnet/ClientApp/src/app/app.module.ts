import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DocenteRegistroComponent } from './inscripcion/docente-registro/docente-registro.component';
import { EstudianteRegistroComponent } from './inscripcion/estudiante-registro/estudiante-registro.component';
import { ProyectoRegistroComponent } from './inscripcion/proyecto-registro/proyecto-registro.component';
import { AppRoutingModule } from './app-routing.module';
import { DocenteService } from './services/docente.service';
import { EstudianteService } from './services/estudiante.service';
import { ProyectoService } from './services/proyecto.service';
import { FooterComponent } from './footer/footer.component';
import { PestanaRegistroComponent } from './inscripcion/pestana-registro/pestana-registro.component';
import { AsignaturaService } from './services/asignatura.service';
import { DatosLocalSService } from './services/datos-local-s.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { PlantillaComiteComponent } from './plantillas/plantilla-comite/plantilla-comite.component';
import { PlantillaLiderComponent } from './plantillas/plantilla-lider/plantilla-lider.component';
import { PlantillaEvaluadorComponent } from './plantillas/plantilla-evaluador/plantilla-evaluador.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DocenteRegistroComponent,
    EstudianteRegistroComponent,
    ProyectoRegistroComponent,
    FooterComponent,
    PestanaRegistroComponent,
    AlertModalComponent,
    PlantillaComiteComponent,
    PlantillaLiderComponent,
    PlantillaEvaluadorComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [
    DocenteService,
    EstudianteService,
    ProyectoService,
    AsignaturaService,
    DatosLocalSService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
