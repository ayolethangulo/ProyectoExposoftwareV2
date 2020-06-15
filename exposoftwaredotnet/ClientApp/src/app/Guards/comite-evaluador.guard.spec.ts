import { TestBed } from '@angular/core/testing';

import { ComiteEvaluadorGuard } from './comite-evaluador.guard';

describe('ComiteEvaluadorGuard', () => {
  let guard: ComiteEvaluadorGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ComiteEvaluadorGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
