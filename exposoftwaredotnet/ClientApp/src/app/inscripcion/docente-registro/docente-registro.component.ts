import { Component, OnInit } from '@angular/core';
import { Docente } from '../models/docente';
import { DocenteService } from '../../services/docente.service';
import { FormGroup, FormBuilder, Validators,  AbstractControl, ValidationErrors } from '@angular/forms';
import { DatosLocalSService } from '../../services/datos-local-s.service';


@Component({
  selector: 'app-docente-registro',
  templateUrl: './docente-registro.component.html',
  styleUrls: ['./docente-registro.component.css']
})

export class DocenteRegistroComponent implements OnInit {

  formGroup: FormGroup;
  docente: Docente;
  id: string = '';
  constructor(
    private docenteService: DocenteService, 
    private formBuilder: FormBuilder,
    private datosLocalS: DatosLocalSService)
    {}

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.docente = new Docente();
    this.docente.identificacion = '';
    this.docente.primerNombre = '';
    this.docente.segundoNombre = '';
    this.docente.primerApellido = '';
    this.docente.segundoApellido = '';
    this.docente.celular = '';
    this.docente.correo = '';
    this.docente.perfil = '';

    this.formGroup = this.formBuilder.group({
      identificacion: [this.docente.identificacion, Validators.required],
      primerNombre: [this.docente.primerNombre, Validators.required],
      segundoNombre: [this.docente.segundoNombre, this.ValidaVacio],
      primerApellido: [this.docente.primerApellido, Validators.required],
      segundoApellido: [this.docente.segundoApellido, Validators.required],
      celular: [this.docente.celular, Validators.maxLength(10)],
      correo: [this.docente.correo, Validators.required],
      perfil: [this.docente.perfil, Validators.required]
     });
  }

  private ValidaVacio(control: AbstractControl) {
    const segundoNombre = control.value;
    if (segundoNombre == '') {
      return null;
    }
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
    //this.buildForm();
  }

  add() {
    this.docente = this.formGroup.value;
    this.guardarLocal(this.docente.identificacion);
    this.docenteService.post(this.docente).subscribe(d => {
      if(d != null){
   
        this.docente = d;
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

  guardarLocal(id: string){
    this.datosLocalS.post(id);
  }


}
