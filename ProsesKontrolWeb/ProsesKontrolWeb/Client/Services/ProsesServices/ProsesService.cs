using Microsoft.AspNetCore.Components;
using ProsesKontrolWeb.Shared.Models;
using System.Net.Http.Json;

namespace ProsesKontrolWeb.Client.Services.ProsesServices
{
    public class ProsesService : IProsesService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ProsesService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ProsesModel> ProsesModels { get; set; } = new List<ProsesModel>();

        public async Task<ProsesModel> AddProses(ProsesModel prosesModel)
        {
            var result = await _http.PostAsJsonAsync("api/proses", prosesModel);
            //await SetProses(result); 
            var response = await result.Content.ReadFromJsonAsync<ProsesModel>();
            return response;
        }
        public async Task<List<ProsesModel>> GetAllProsesModels()
        {
            var result = await _http.GetFromJsonAsync<List<ProsesModel>>("api/proses");
            if (result != null)
                ProsesModels = result;

            return ProsesModels;
        }
        public async Task<ProsesModel> GetProsesById(int id)
        {
            var result = await _http.GetFromJsonAsync<ProsesModel>($"api/proses/{id}");
            if (result != null)
                return result;
            else
                throw new Exception("Veri Bulunamadı !");
        }
        public async Task UpdateProses(ProsesModel prosesModel)
        {
            var result = await _http.PutAsJsonAsync($"api/proses/Update/{prosesModel.Id}", prosesModel);
            await SetProses(result);
        }
        public async Task DeleteProses(int id)
        {
            var result = await _http.DeleteAsync($"api/proses/Delete/{id}");
            await SetProses(result);
        }
        private async Task SetProses(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProsesModel>>();

            ProsesModels = response;
           // _navigationManager.NavigateTo("prosesler");
        }
        public async Task<List<ProsesModel>> GetProsesModelsByUniteId(int? uniteId)
        {
            if (uniteId == null)
            {
                return null;
            }
            var result = await _http.GetFromJsonAsync<List<ProsesModel>>($"api/proses/Filtre/{uniteId}");
            if (result != null)
                ProsesModels = result;
            return ProsesModels;
        }
    }
}
