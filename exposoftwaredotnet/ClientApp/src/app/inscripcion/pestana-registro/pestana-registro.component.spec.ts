import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PestanaRegistroComponent } from './pestana-registro.component';

describe('PestanaRegistroComponent', () => {
  let component: PestanaRegistroComponent;
  let fixture: ComponentFixture<PestanaRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PestanaRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PestanaRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
