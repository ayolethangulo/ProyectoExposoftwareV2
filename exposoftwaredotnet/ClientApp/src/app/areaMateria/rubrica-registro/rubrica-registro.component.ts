import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, ValidationErrors, Validators, FormArray } from '@angular/forms';
import { Area } from '../models/area';
import { Rubrica } from '../models/rubrica';
import { ItemsRubrica } from '../models/items-rubrica';
import { AreaService } from 'src/app/services/area.service';
import { RubricaService } from 'src/app/services/rubrica.service';
import { ItemsRubricaService } from 'src/app/services/items-rubrica.service';

@Component({
  selector: 'app-rubrica-registro',
  templateUrl: './rubrica-registro.component.html',
  styleUrls: ['./rubrica-registro.component.css']
})
export class RubricaRegistroComponent implements OnInit {

  formGroupRubrica: FormGroup;
  formGroupItems: FormGroup;
  rubrica: Rubrica;
  itemsRubrica: ItemsRubrica;
  areas: Area[];
  constructor(private areaService: AreaService, private formBuilder: FormBuilder,
    private rubricaService: RubricaService, private itemsRubricaService: ItemsRubricaService) { }

  ngOnInit(): void {
    this.buildFormRubrica();
    this.buildFormItem();
    this.cargarArea();
  }

  private buildFormRubrica() {
    this.rubrica = new Rubrica();
    this.rubrica.idRubrica = '';
    this.rubrica.idArea = '';

    this.formGroupRubrica = this.formBuilder.group({
      idRubrica: [this.rubrica.idRubrica, Validators.required],
      idArea: [this.rubrica.idArea, Validators.required]
    });
  }

  private buildFormItem() {
    this.itemsRubrica = new ItemsRubrica();
    this.itemsRubrica.idRubrica = '1';
    this.itemsRubrica.item = '';
    this.itemsRubrica.descripcion = '';

    this.formGroupItems = this.formBuilder.group({
      idRubrica: [this.itemsRubrica.idRubrica, Validators.required],
      item: [this.itemsRubrica.item, Validators.required],
      descripcion: [this.itemsRubrica.descripcion, Validators.required]
    });
  }

  onSubmit() {
    if (this.formGroupRubrica.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.rubrica = this.formGroupRubrica.value;
    this.rubricaService.post(this.rubrica).subscribe(r => {
      if (r != null) {
        this.rubrica = r;
      }
    });
  }

  agregarItems() {
    this.itemsRubrica = this.formGroupItems.value;
    this.itemsRubricaService.post(this.itemsRubrica).subscribe(ir => {
      if (ir != null) {
        this.itemsRubrica = ir;
      }
    });
  }

  public cargarArea() {
    this.areaService.get().subscribe(result => {
      this.areas = result;
    });
  }

  public getError(controlName: string): string {
    let error = '';
    const control = this.formGroupRubrica.get(controlName);
    if (control.touched && control.errors != null) {
      error = JSON.stringify(control.errors);
    }
    return error;
  }

  public getErrorV(controlName: string): ValidationErrors {
    return this.formGroupRubrica.get(controlName).errors;
  }
  get f() { return this.formGroupRubrica.controls; }
  get control() { return this.formGroupRubrica.controls; }

}
