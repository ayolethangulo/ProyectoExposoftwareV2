import { Component, OnInit } from '@angular/core';
import { Asignatura } from '../models/asignatura';
import { AsignaturaService } from '../../services/asignatura.service';
import { FormGroup, FormBuilder, Validators,  AbstractControl, ValidationErrors } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-asignatura-registro',
  templateUrl: './asignatura-registro.component.html',
  styleUrls: ['./asignatura-registro.component.css']
})
export class AsignaturaRegistroComponent implements OnInit {

  formGroup: FormGroup;
  asignatura: Asignatura;
  constructor(
    private asignaturaService: AsignaturaService, private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.asignatura = new Asignatura();
    this.asignatura.idAsignatura = '';
    this.asignatura.nombreAsignatura = '';
    this.asignatura.idArea = '';


    this.formGroup = this.formBuilder.group({
      idAsignatura: [this.asignatura.idAsignatura, Validators.required],
      nombreAsignatura: [this.asignatura.nombreAsignatura, Validators.required],
      idArea: [this.asignatura.idArea, Validators.required]
     });
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }
  add() {
    this.asignatura = this.formGroup.value;
    this.asignaturaService.post(this.asignatura).subscribe(a => {
      if (a != null) {
        this.asignatura = a;
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
