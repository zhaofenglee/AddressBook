using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using JS.Abp.AddressBook.EmailAddressBooks;
using JS.Abp.AddressBook.Permissions;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.Blazor.Pages
{
    public partial class EmailAddressBooks
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        private IReadOnlyList<EmailAddressBookDto> EmailAddressBookList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private bool CanCreateEmailAddressBook { get; set; }
        private bool CanEditEmailAddressBook { get; set; }
        private bool CanDeleteEmailAddressBook { get; set; }
        private EmailAddressBookCreateDto NewEmailAddressBook { get; set; }
        private Validations NewEmailAddressBookValidations { get; set; }
        private EmailAddressBookUpdateDto EditingEmailAddressBook { get; set; }
        private Validations EditingEmailAddressBookValidations { get; set; }
        private Guid EditingEmailAddressBookId { get; set; }
        private Modal CreateEmailAddressBookModal { get; set; }
        private Modal EditEmailAddressBookModal { get; set; }
        private GetEmailAddressBooksInput Filter { get; set; }
        private DataGridEntityActionsColumn<EmailAddressBookDto> EntityActionsColumn { get; set; }
        protected string SelectedCreateTab = "emailAddressBook-create-tab";
        protected string SelectedEditTab = "emailAddressBook-edit-tab";
        
        public EmailAddressBooks()
        {
            NewEmailAddressBook = new EmailAddressBookCreateDto();
            EditingEmailAddressBook = new EmailAddressBookUpdateDto();
            Filter = new GetEmailAddressBooksInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
        }

        protected override async Task OnInitializedAsync()
        {
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
            await SetPermissionsAsync();
        }

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:EmailAddressBooks"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["ExportToExcel"], async () =>{ await DownloadAsExcelAsync(); }, IconName.Download);
            
            Toolbar.AddButton(L["NewEmailAddressBook"], async () =>
            {
                await OpenCreateEmailAddressBookModalAsync();
            }, IconName.Add, requiredPolicyName: AddressBookPermissions.EmailAddressBooks.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateEmailAddressBook = await AuthorizationService
                .IsGrantedAsync(AddressBookPermissions.EmailAddressBooks.Create);
            CanEditEmailAddressBook = await AuthorizationService
                            .IsGrantedAsync(AddressBookPermissions.EmailAddressBooks.Edit);
            CanDeleteEmailAddressBook = await AuthorizationService
                            .IsGrantedAsync(AddressBookPermissions.EmailAddressBooks.Delete);
        }

        private async Task GetEmailAddressBooksAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await EmailAddressBooksAppService.GetListAsync(Filter);
            EmailAddressBookList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetEmailAddressBooksAsync();
            await InvokeAsync(StateHasChanged);
        }

        private  async Task DownloadAsExcelAsync()
        {
            var token = (await EmailAddressBooksAppService.GetDownloadTokenAsync()).Token;
            NavigationManager.NavigateTo($"/api/app/email-address-books/as-excel-file?DownloadToken={token}&FilterText={Filter.FilterText}", forceLoad: true);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<EmailAddressBookDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetEmailAddressBooksAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateEmailAddressBookModalAsync()
        {
            NewEmailAddressBook = new EmailAddressBookCreateDto{
                
                
            };
            await NewEmailAddressBookValidations.ClearAll();
            await CreateEmailAddressBookModal.Show();
        }

        private async Task CloseCreateEmailAddressBookModalAsync()
        {
            NewEmailAddressBook = new EmailAddressBookCreateDto{
                
                
            };
            await CreateEmailAddressBookModal.Hide();
        }

        private async Task OpenEditEmailAddressBookModalAsync(EmailAddressBookDto input)
        {
            var emailAddressBook = await EmailAddressBooksAppService.GetAsync(input.Id);
            
            EditingEmailAddressBookId = emailAddressBook.Id;
            EditingEmailAddressBook = ObjectMapper.Map<EmailAddressBookDto, EmailAddressBookUpdateDto>(emailAddressBook);
            await EditingEmailAddressBookValidations.ClearAll();
            await EditEmailAddressBookModal.Show();
        }

        private async Task DeleteEmailAddressBookAsync(EmailAddressBookDto input)
        {
            await EmailAddressBooksAppService.DeleteAsync(input.Id);
            await GetEmailAddressBooksAsync();
        }

        private async Task CreateEmailAddressBookAsync()
        {
            try
            {
                if (await NewEmailAddressBookValidations.ValidateAll() == false)
                {
                    return;
                }

                await EmailAddressBooksAppService.CreateAsync(NewEmailAddressBook);
                await GetEmailAddressBooksAsync();
                await CloseCreateEmailAddressBookModalAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private async Task CloseEditEmailAddressBookModalAsync()
        {
            await EditEmailAddressBookModal.Hide();
        }

        private async Task UpdateEmailAddressBookAsync()
        {
            try
            {
                if (await EditingEmailAddressBookValidations.ValidateAll() == false)
                {
                    return;
                }

                await EmailAddressBooksAppService.UpdateAsync(EditingEmailAddressBookId, EditingEmailAddressBook);
                await GetEmailAddressBooksAsync();
                await EditEmailAddressBookModal.Hide();                
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private void OnSelectedCreateTabChanged(string name)
        {
            SelectedCreateTab = name;
        }

        private void OnSelectedEditTabChanged(string name)
        {
            SelectedEditTab = name;
        }
        

    }
}
