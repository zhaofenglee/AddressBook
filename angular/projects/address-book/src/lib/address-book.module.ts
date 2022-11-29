import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AddressBookComponent } from './components/address-book.component';
import { AddressBookRoutingModule } from './address-book-routing.module';

@NgModule({
  declarations: [AddressBookComponent],
  imports: [CoreModule, ThemeSharedModule, AddressBookRoutingModule],
  exports: [AddressBookComponent],
})
export class AddressBookModule {
  static forChild(): ModuleWithProviders<AddressBookModule> {
    return {
      ngModule: AddressBookModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AddressBookModule> {
    return new LazyModuleFactory(AddressBookModule.forChild());
  }
}
