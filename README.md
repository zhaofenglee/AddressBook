# AddressBook

## Getting Started

### 1.Install the following NuGet packages.
  * JS.Abp.AddressBook.Application
  * JS.Abp.AddressBook.Application.Contracts
  * JS.Abp.AddressBook.Domain
  * JS.Abp.AddressBook.Domain.Shared
  * JS.Abp.AddressBook.EntityFrameworkCore
  * JS.Abp.AddressBook.HttpApi
  * JS.Abp.AddressBook.HttpApi.Client
  
### 2.Add `DependsOn` attribute to configure the module
 * [DependsOn(typeof(AddressBookApplicationModule))]
 * [DependsOn(typeof(AddressBookApplicationContractsModule))]
 * [DependsOn(typeof(AddressBookDomainModule))]
 * [DependsOn(typeof(AddressBookDomainSharedModule))]
 * [DependsOn(typeof(AddressBookEntityFrameworkCoreModule))]
 * [DependsOn(typeof(AddressBookHttpApiModule))]
 * [DependsOn(typeof(AddressBookHttpApiClientModule))]
 * [DependsOn(typeof(AddressBookBlazorModule))]
 * [DependsOn(typeof(AddressBookBlazorServerModule))]
 * [DependsOn(typeof(AddressBookBlazorWebAssemblyModule))]
### 3. Add ` builder.ConfigureAddressBook();` to the `OnModelCreating()` method in **YourProjectDbContext.cs**.

### 4. Add EF Core migrations and update your database.
Open a command-line terminal in the directory of the YourProject.EntityFrameworkCore project and type the following command:

````bash
> dotnet ef migrations add Added_AddressBook
````
````bash
> dotnet ef database update
````

## Samples

See the [sample projects](https://github.com/zhaofenglee/JS.Abp.AddressBook/tree/master/host/JS.Abp.AddressBook.Blazor.Host)
