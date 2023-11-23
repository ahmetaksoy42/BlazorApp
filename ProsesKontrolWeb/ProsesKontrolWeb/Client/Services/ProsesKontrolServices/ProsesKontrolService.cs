using Microsoft.AspNetCore.Components;
using ProsesKontrolWeb.Shared.Models;
using Syncfusion.Blazor.Charts;
using System.Net.Http.Json;

namespace ProsesKontrolWeb.Client.Services.ProsesKontrolServices
{
    public class ProsesKontrolService : IProsesKontrolService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ProsesKontrolService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ProsesKontrolModel> ProsesKontrolModels { get; set; } = new List<ProsesKontrolModel>();

        public async Task<List<ProsesKontrolModel>> GetProsesKontrolModels()
        {

            var result = await _http.GetFromJsonAsync<List<ProsesKontrolModel>>("api/proseskontrol");
            if (result != null)
                ProsesKontrolModels = result;


            return ProsesKontrolModels;
        }
        public async Task<ProsesKontrolModel> GetProsesById(int id)
        {
            var result = await _http.GetFromJsonAsync<ProsesKontrolModel>($"api/proseskontrol/{id}");
            if (result != null)
                return result;
            else
                throw new Exception("Veri Bulunamadı !");
        }

        public async Task<ProsesKontrolModel> AddProses(ProsesKontrolModel prosesKontrolModel)
        {
            var result = await _http.PostAsJsonAsync("api/proseskontrol", prosesKontrolModel);
            //await SetProses(result); 
            var response = await result.Content.ReadFromJsonAsync<ProsesKontrolModel>();
            return response;
        }

        //eski
        //public async Task AddProses(ProsesKontrolModel prosesKontrolModel)
        //{
        //    var result = await _http.PostAsJsonAsync("api/proses", prosesKontrolModel);
        //    await SetProses(result);
        //    //var response= result.Content.ReadFromJsonAsync<ProsesKontrolModel>();
        //    //return response.Result;
        //}

        public async Task UpdateProses(ProsesKontrolModel prosesKontrolModel)
        {
            var result = await _http.PutAsJsonAsync($"api/proseskontrol/Update/{prosesKontrolModel.Id}", prosesKontrolModel);
            await SetProses(result);
        }
        public async Task DeleteProses(int id)
        {
            var result = await _http.DeleteAsync($"api/proseskontrol/Delete/{id}");
            await SetProses(result);
        }
        private async Task SetProses(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProsesKontrolModel>>();

            ProsesKontrolModels = response;
            // _navigationManager.NavigateTo("veriler");
        }

        public async Task<List<ProsesKontrolModel>> GetProsesKontrolModelsByProsesId(int? prosesId)
        {
            if (prosesId == null)
            {
                return null;
            }
            var result = await _http.GetFromJsonAsync<List<ProsesKontrolModel>>($"api/proseskontrol/Filtre/{prosesId}");
                if (result != null)
                    ProsesKontrolModels = result;
            return ProsesKontrolModels;
        }
    }
}
