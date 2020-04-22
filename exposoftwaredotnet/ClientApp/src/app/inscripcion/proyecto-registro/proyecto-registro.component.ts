import { Component, OnInit } from '@angular/core';
import { Proyecto } from '../models/proyecto';
import { ProyectoService } from '../../services/proyecto.service';
import { FormGroup, FormBuilder, Validators,  AbstractControl, ValidationErrors} from '@angular/forms';

@Component({
  selector: 'app-proyecto-registro',
  templateUrl: './proyecto-registro.component.html',
  styleUrls: ['./proyecto-registro.component.css']
})
export class ProyectoRegistroComponent implements OnInit {

  formGroup: FormGroup;
  proyecto: Proyecto;
  constructor(private proyectoService: ProyectoService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
    this.proyecto = new Proyecto();
  }

  private buildForm() {
    this.proyecto = new Proyecto();
    this.proyecto.titulo = '';
    this.proyecto.asignatura = '';
    this.proyecto.semestre = '';
    this.proyecto.resumen = '';
    this.proyecto.metodologia = '';
    this.proyecto.resultados = '';

    this.formGroup = this.formBuilder.group({
      titulo: [this.proyecto.titulo, Validators.required],
      asignatura: [this.proyecto.asignatura, Validators.required],
      semestre: [this.proyecto.semestre, Validators.required],
      resumen: [this.proyecto.resumen, Validators.required],
      metodologia: [this.proyecto.metodologia, Validators.required],
      resultados: [this.proyecto.resultados, Validators.required]
     });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
    this.buildForm();
  }

  add(){
    this.proyectoService.post(this.proyecto).subscribe(p => {
      if(p != null){
        alert('Proyecto Registrado');
        this.proyecto = p;
      }
    });
  }

  public getError(controlName: string): string {
    let error = '';
    const control = this.formGroup.get(controlName);
    if (control.touched && control.errors != null) {
      error = JSON.stringify(control.errors);
    }
    return error;
  }

  public getErrorV(controlName: string): ValidationErrors {
    return this.formGroup.get(controlName).errors;
  }
  get f() { return this.formGroup.controls; }
  
  get control() { return this.formGroup.controls; }

}
