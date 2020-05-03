import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillaLiderComponent } from './plantilla-lider.component';

describe('PlantillaLiderComponent', () => {
  let component: PlantillaLiderComponent;
  let fixture: ComponentFixture<PlantillaLiderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlantillaLiderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantillaLiderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
