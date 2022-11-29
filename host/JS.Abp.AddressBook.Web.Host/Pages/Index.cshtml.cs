using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace JS.Abp.AddressBook.Pages;

public class IndexModel : AddressBookPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
