import { DocenteRegistroComponent } from './inscripcion/docente-registro/docente-registro.component';
import { EstudianteRegistroComponent } from './inscripcion/estudiante-registro/estudiante-registro.component';
import { ProyectoRegistroComponent } from './inscripcion/proyecto-registro/proyecto-registro.component';
import { PestanaRegistroComponent } from './inscripcion/pestana-registro/pestana-registro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { InformacionComponent } from './informacion/informacion/informacion.component';
import { LoginComiteEvaluadorComponent } from './loginComiteEvaluador/login-comite-evaluador/login-comite-evaluador.component';
import { LoginDocenteEvaluadorComponent } from './loginDocenteEvaluador/login-docente-evaluador/login-docente-evaluador.component';
import { LoginLiderProyectoComponent } from './loginLiderProyecto/login-lider-proyecto/login-lider-proyecto.component';
import { EvaluaInscripcionComponent } from './ComiteEvaluador/evalua-inscripcion/evalua-inscripcion.component';
import { EvaluarPendonComponent } from './ComiteEvaluador/evaluar-pendon/evaluar-pendon.component';
import { InicioComponent } from './ComiteEvaluador/inicio/inicio.component';
import { ModificarRubricaComponent } from './ComiteEvaluador/modificar-rubrica/modificar-rubrica.component';
import { RegistrarComiteEvaluadorComponent } from './ComiteEvaluador/registrar-comite-evaluador/registrar-comite-evaluador.component';
import { RegistrarDocenteEvaluadorComponent } from './ComiteEvaluador/registrar-docente-evaluador/registrar-docente-evaluador.component';
import { InicioLiderComponent } from './DocenteLider/InicioLider/inicio-lider/inicio-lider.component';
import { RegistrarPendonComponent } from './DocenteLider/RegistrarPendon/registrar-pendon/registrar-pendon.component';
import { ConsultaResultadoComponent } from './DocenteLider/ConsultaResultado/consulta-resultado/consulta-resultado.component';


const routes: Routes = [
  {
  path: 'proyectoRegistro',
  component: ProyectoRegistroComponent
  },
  {
    path: 'docenteRegistro',
    component: DocenteRegistroComponent
  },
  {
    path: 'estudianteRegistro',
    component: EstudianteRegistroComponent
  },
  {
    path: 'pestanaRegistro',
    component: PestanaRegistroComponent
  },
  {
    path: 'loginLider',
    component: LoginLiderProyectoComponent

  },
  {
    path: 'LoginDocenteEvaluador',
    component: LoginDocenteEvaluadorComponent

  },
  {
    path: 'LoginComiteEvaluador',
    component: LoginComiteEvaluadorComponent

  },
  {
    path: 'Informacion',
    component: InformacionComponent

  },
  {
    path: 'evaluaInscripcion',
    component: EvaluaInscripcionComponent
  },
  {
    path: 'evaluarPendon',
    component: EvaluarPendonComponent
  },
  {
    path: 'inicio',
    component: InicioComponent
  },
  {
    path: 'modificarRubrica',
    component: ModificarRubricaComponent
  },
  {
    path: 'registrarComiteEvaluador',
    component: RegistrarComiteEvaluadorComponent
  },
  {
    path: 'registrarDocenteEvaluador',
    component: RegistrarDocenteEvaluadorComponent
  },
  {
    path: 'InicioDocenteLider',
    component: InicioLiderComponent
  }, 
  {
    path: 'RegistrarPendon',
    component: RegistrarPendonComponent
  },
  {
    path: 'ConsultaResultado',
    component: ConsultaResultadoComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
})
export class AppRoutingModule { }
