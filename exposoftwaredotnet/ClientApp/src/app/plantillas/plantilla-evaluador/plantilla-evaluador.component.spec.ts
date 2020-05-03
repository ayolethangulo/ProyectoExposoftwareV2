import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillaEvaluadorComponent } from './plantilla-evaluador.component';

describe('PlantillaEvaluadorComponent', () => {
  let component: PlantillaEvaluadorComponent;
  let fixture: ComponentFixture<PlantillaEvaluadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlantillaEvaluadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantillaEvaluadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
