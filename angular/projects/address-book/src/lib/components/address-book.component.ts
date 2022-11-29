import { Component, OnInit } from '@angular/core';
import { AddressBookService } from '../services/address-book.service';

@Component({
  selector: 'lib-address-book',
  template: ` <p>address-book works!</p> `,
  styles: [],
})
export class AddressBookComponent implements OnInit {
  constructor(private service: AddressBookService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
