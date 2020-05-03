import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificarRubricaComponent } from './modificar-rubrica.component';

describe('ModificarRubricaComponent', () => {
  let component: ModificarRubricaComponent;
  let fixture: ComponentFixture<ModificarRubricaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarRubricaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificarRubricaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
