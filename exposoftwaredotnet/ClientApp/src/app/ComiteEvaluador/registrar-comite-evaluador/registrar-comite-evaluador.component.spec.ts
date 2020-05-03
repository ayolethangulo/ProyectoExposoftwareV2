import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarComiteEvaluadorComponent } from './registrar-comite-evaluador.component';

describe('RegistrarComiteEvaluadorComponent', () => {
  let component: RegistrarComiteEvaluadorComponent;
  let fixture: ComponentFixture<RegistrarComiteEvaluadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarComiteEvaluadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarComiteEvaluadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
