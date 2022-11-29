import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class AddressBookService {
  apiName = 'AddressBook';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/AddressBook/sample' },
      { apiName: this.apiName }
    );
  }
}
