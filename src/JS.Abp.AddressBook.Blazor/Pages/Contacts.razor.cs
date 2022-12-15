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
using JS.Abp.AddressBook.Contacts;
using JS.Abp.AddressBook.Permissions;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.Blazor.Pages
{
    public partial class Contacts
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        private IReadOnlyList<ContactDto> ContactList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private bool CanCreateContact { get; set; }
        private bool CanEditContact { get; set; }
        private bool CanDeleteContact { get; set; }
        private ContactCreateDto NewContact { get; set; }
        private Validations NewContactValidations { get; set; }
        private ContactUpdateDto EditingContact { get; set; }
        private Validations EditingContactValidations { get; set; }
        private Guid EditingContactId { get; set; }
        private Modal CreateContactModal { get; set; }
        private Modal EditContactModal { get; set; }
        private GetContactsInput Filter { get; set; }
        private DataGridEntityActionsColumn<ContactDto> EntityActionsColumn { get; set; }
        protected string SelectedCreateTab = "contact-create-tab";
        protected string SelectedEditTab = "contact-edit-tab";
        
        public Contacts()
        {
            NewContact = new ContactCreateDto();
            EditingContact = new ContactUpdateDto();
            Filter = new GetContactsInput
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
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:Contacts"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["ExportToExcel"], async () =>{ await DownloadAsExcelAsync(); }, IconName.Download);
            
            Toolbar.AddButton(L["NewContact"], async () =>
            {
                await OpenCreateContactModalAsync();
            }, IconName.Add, requiredPolicyName: AddressBookPermissions.Contacts.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateContact = await AuthorizationService
                .IsGrantedAsync(AddressBookPermissions.Contacts.Create);
            CanEditContact = await AuthorizationService
                            .IsGrantedAsync(AddressBookPermissions.Contacts.Edit);
            CanDeleteContact = await AuthorizationService
                            .IsGrantedAsync(AddressBookPermissions.Contacts.Delete);
        }

        private async Task GetContactsAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await ContactsAppService.GetListAsync(Filter);
            ContactList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetContactsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private  async Task DownloadAsExcelAsync()
        {
            var token = (await ContactsAppService.GetDownloadTokenAsync()).Token;
            var remoteService = await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultAsync("Default");
            NavigationManager.NavigateTo($"{remoteService.BaseUrl.EnsureEndsWith('/')}api/app/contacts/as-excel-file?DownloadToken={token}&FilterText={Filter.FilterText}", forceLoad: true);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ContactDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetContactsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateContactModalAsync()
        {
            NewContact = new ContactCreateDto{
            };
            await NewContactValidations.ClearAll();
            await CreateContactModal.Show();
        }

        private async Task CloseCreateContactModalAsync()
        {
            NewContact = new ContactCreateDto{
                Birthday = DateTime.Now,

                
            };
            await CreateContactModal.Hide();
        }

        private async Task OpenEditContactModalAsync(ContactDto input)
        {
            var contact = await ContactsAppService.GetAsync(input.Id);
            
            EditingContactId = contact.Id;
            EditingContact = ObjectMapper.Map<ContactDto, ContactUpdateDto>(contact);
            await EditingContactValidations.ClearAll();
            await EditContactModal.Show();
        }

        private async Task DeleteContactAsync(ContactDto input)
        {
            await ContactsAppService.DeleteAsync(input.Id);
            await GetContactsAsync();
        }

        private async Task CreateContactAsync()
        {
            try
            {
                if (await NewContactValidations.ValidateAll() == false)
                {
                    return;
                }

                await ContactsAppService.CreateAsync(NewContact);
                await GetContactsAsync();
                await CloseCreateContactModalAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private async Task CloseEditContactModalAsync()
        {
            await EditContactModal.Hide();
        }

        private async Task UpdateContactAsync()
        {
            try
            {
                if (await EditingContactValidations.ValidateAll() == false)
                {
                    return;
                }

                await ContactsAppService.UpdateAsync(EditingContactId, EditingContact);
                await GetContactsAsync();
                await EditContactModal.Hide();                
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
