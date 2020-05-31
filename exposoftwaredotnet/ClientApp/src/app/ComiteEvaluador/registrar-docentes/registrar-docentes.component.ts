import { Component, OnInit } from '@angular/core';
import { DocenteService } from 'src/app/services/docente.service';
import { Docente } from 'src/app/inscripcion/models/docente';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';


@Component({
  selector: 'app-registrar-docentes',
  templateUrl: './registrar-docentes.component.html',
  styleUrls: ['./registrar-docentes.component.css']
})
export class RegistrarDocentesComponent implements OnInit {

  formGroup: FormGroup;
  docente: Docente;
  constructor(private docenteService: DocenteService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
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
    this.docente.tipoDocente = '';

    this.formGroup = this.formBuilder.group({
      identificacion: [this.docente.identificacion, Validators.required],
      primerNombre: [this.docente.primerNombre, Validators.required],
      segundoNombre: [this.docente.segundoNombre, this.ValidaVacio],
      primerApellido: [this.docente.primerApellido, Validators.required],
      segundoApellido: [this.docente.segundoApellido, Validators.required],
      celular: [this.docente.celular, Validators.maxLength(10)],
      correo: [this.docente.correo, Validators.required],
      perfil: [this.docente.perfil, Validators.required],
      tipoDocente: [this.docente.tipoDocente, Validators.required]
    });
  }

  private ValidaVacio(control: AbstractControl) {
    const segundoNombre = control.value;
    if (segundoNombre == null) {
      return null;
    }
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.docente = this.formGroup.value;
    this.docenteService.post(this.docente).subscribe(d => {
      if (d != null) {
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

  buscar() {
    const idb = this.formGroup.get('identificacion').value;
    if (idb == '') {
      const messageBox = this.modalService.open(AlertModalComponent);
      messageBox.componentInstance.title = 'Resultado Operación';
      messageBox.componentInstance.message = 'Campo vacío, digite identificación.';
    } else {
      this.docenteService.getId(idb).subscribe(d => {
        if (d != null) {
          this.docente = d;
          this.mapearDocente(this.docente);
        } else {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = 'Resultado Operación';
          messageBox.componentInstance.message = 'Docente no registrado';
        }
      });
    }
  }

  mapearDocente(d: Docente) {
    this.formGroup.get('primerNombre').setValue(d.primerNombre);
    if (d.segundoNombre == null) {
      this.formGroup.get('segundoNombre').setValue('');
    } else {
      this.formGroup.get('segundoNombre').setValue(d.segundoNombre);
    }
    this.formGroup.get('primerApellido').setValue(d.primerApellido);
    this.formGroup.get('segundoApellido').setValue(d.segundoApellido);
    this.formGroup.get('celular').setValue(d.celular);
    this.formGroup.get('correo').setValue(d.correo);
    this.formGroup.get('perfil').setValue(d.perfil);
    this.formGroup.get('tipoDocente').setValue(d.tipoDocente);
  }
}
