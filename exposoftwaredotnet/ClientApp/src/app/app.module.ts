import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
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
import { InformacionComponent } from './informacion/informacion/informacion.component';
import { LoginComiteEvaluadorComponent } from './loginComiteEvaluador/login-comite-evaluador/login-comite-evaluador.component';
import { LoginDocenteEvaluadorComponent } from './loginDocenteEvaluador/login-docente-evaluador/login-docente-evaluador.component';
import { LoginLiderProyectoComponent } from './loginLiderProyecto/login-lider-proyecto/login-lider-proyecto.component';
import { InicioComponent } from './ComiteEvaluador/inicio/inicio.component';
import { ModificarRubricaComponent } from './ComiteEvaluador/modificar-rubrica/modificar-rubrica.component';
import { EvaluarPendonComponent } from './ComiteEvaluador/evaluar-pendon/evaluar-pendon.component';
import { EvaluaInscripcionComponent } from './ComiteEvaluador/evalua-inscripcion/evalua-inscripcion.component';
import { RegistrarPendonComponent } from './DocenteLider/RegistrarPendon/registrar-pendon/registrar-pendon.component';
import { ConsultaResultadoComponent } from './DocenteLider/ConsultaResultado/consulta-resultado/consulta-resultado.component';
import { InicioLiderComponent } from './DocenteLider/InicioLider/inicio-lider/inicio-lider.component';
import { UsuarioService } from './services/usuario.service';
import { RegistrarUsuarioComponent } from './ComiteEvaluador/registrar-usuario/registrar-usuario.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DocenteRegistroComponent,
    EstudianteRegistroComponent,
    ProyectoRegistroComponent,
    FooterComponent,
    PestanaRegistroComponent,
    AlertModalComponent,
    InformacionComponent,
    LoginComiteEvaluadorComponent,
    LoginDocenteEvaluadorComponent,
    LoginLiderProyectoComponent,
    InicioComponent,
    ModificarRubricaComponent,
    EvaluarPendonComponent,
    EvaluaInscripcionComponent,
    RegistrarPendonComponent,
    ConsultaResultadoComponent,
    InicioLiderComponent,
    RegistrarUsuarioComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
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
    DatosLocalSService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
