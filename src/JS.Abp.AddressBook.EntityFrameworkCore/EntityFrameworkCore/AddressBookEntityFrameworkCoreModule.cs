using JS.Abp.AddressBook.EmailAddressBooks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

[DependsOn(
    typeof(AddressBookDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AddressBookEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AddressBookDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<EmailAddressBook, EfCoreEmailAddressBookRepository>();
        });
    }
}
