import { TestBed } from '@angular/core/testing';
import { AddressBookService } from './services/address-book.service';
import { RestService } from '@abp/ng.core';

describe('AddressBookService', () => {
  let service: AddressBookService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(AddressBookService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
