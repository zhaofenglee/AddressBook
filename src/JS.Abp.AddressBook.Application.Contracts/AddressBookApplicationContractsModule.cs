﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AddressBookDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AddressBookApplicationContractsModule : AbpModule
{

}
