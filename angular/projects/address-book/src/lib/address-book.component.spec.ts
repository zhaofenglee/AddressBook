import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { AddressBookComponent } from './components/address-book.component';
import { AddressBookService } from '@j-s.Abp/address-book';
import { of } from 'rxjs';

describe('AddressBookComponent', () => {
  let component: AddressBookComponent;
  let fixture: ComponentFixture<AddressBookComponent>;
  const mockAddressBookService = jasmine.createSpyObj('AddressBookService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [AddressBookComponent],
      providers: [
        {
          provide: AddressBookService,
          useValue: mockAddressBookService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
