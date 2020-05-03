import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillaComiteComponent } from './plantilla-comite.component';

describe('PlantillaComiteComponent', () => {
  let component: PlantillaComiteComponent;
  let fixture: ComponentFixture<PlantillaComiteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlantillaComiteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantillaComiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
