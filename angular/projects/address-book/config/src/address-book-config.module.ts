import { ModuleWithProviders, NgModule } from '@angular/core';
import { ADDRESS_BOOK_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class AddressBookConfigModule {
  static forRoot(): ModuleWithProviders<AddressBookConfigModule> {
    return {
      ngModule: AddressBookConfigModule,
      providers: [ADDRESS_BOOK_ROUTE_PROVIDERS],
    };
  }
}
