using CurrieTechnologies.Razor.SweetAlert2;
using GuateShop.Frontend.Repositories;
using GuateShop.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace GuateShop.Frontend.Pages.Contries
{
    [Authorize(Roles = "Admin")]

    public partial class CountriesIndex
    {
        private int currentPage = 1;
        private int totalPages;
        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;

        public List<Country>? Countries { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadAsync();

        }

        private async Task SelectedPageAsync(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task LoadAsync(int page = 1)
        {
            var ok = await LoadListAsync(page);
            if (ok)
            {
                await LoadPagesAsync();
            }

        }

        private async Task<bool> LoadListAsync(int page)
        {
            var url = $"api/countries?page={page}";
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }
            var responseHttp = await repository.GetAsync<List<Country>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            Countries = responseHttp.Response;
            return true;
        }

        private async Task LoadPagesAsync()
        {
            var url = "api/countries/totalPages";
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"?filter={Uri.EscapeDataString(Filter)}";
            }

            var responseHttp = await repository.GetAsync<int>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
            }
            totalPages = responseHttp.Response;
        }

        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await AppliFilterAsync();
        }

        private async Task AppliFilterAsync()
        {
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task DeleteAsync(Country country)
        {
            var resutl = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "¿Estas seguro de salir?",
                Text = $"¿Estas seguro de aliminar el pais: {country.Name}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });
            var confirm = string.IsNullOrEmpty(resutl.Value);
            if (confirm)
            {
                return;
            }
            var responseHttp = await repository.DeleteAsync<Country>($"api/countries/{country.Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.ResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/countries");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
            }
            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = false,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro borrado con éxito.");
        }

    }
}