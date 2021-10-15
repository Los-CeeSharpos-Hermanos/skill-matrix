import { TestBed } from '@angular/core/testing';

import { EditLangugaeService } from './edit-langugae.service';

describe('EditLangugaeService', () => {
  let service: EditLangugaeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditLangugaeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
