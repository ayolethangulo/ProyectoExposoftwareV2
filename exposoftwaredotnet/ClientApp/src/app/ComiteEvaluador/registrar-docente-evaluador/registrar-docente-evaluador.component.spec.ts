import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarDocenteEvaluadorComponent } from './registrar-docente-evaluador.component';

describe('RegistrarDocenteEvaluadorComponent', () => {
  let component: RegistrarDocenteEvaluadorComponent;
  let fixture: ComponentFixture<RegistrarDocenteEvaluadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarDocenteEvaluadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarDocenteEvaluadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
