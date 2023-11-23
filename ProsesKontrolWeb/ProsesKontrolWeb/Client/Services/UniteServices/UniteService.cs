using Microsoft.AspNetCore.Components;
using ProsesKontrolWeb.Shared.Models;
using Syncfusion.Blazor.Calendars;
using System.Net.Http.Json;

namespace ProsesKontrolWeb.Client.Services.UniteServices
{
    public class UniteService : IUniteService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public UniteService (HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<UniteModel> UniteModels { get ; set ; }

        public async Task<UniteModel> AddUnite(UniteModel uniteModel)
        {
            var result = await _http.PostAsJsonAsync("api/unite", uniteModel);
            //await SetProses(result); 
            var response = await result.Content.ReadFromJsonAsync<UniteModel>();
            return response;
        }
        public async Task DeleteUnite(int id)
        {
            var result = await _http.DeleteAsync($"api/unite/Delete/{id}");
            await SetProses(result);
        }
        public async Task<List<UniteModel>> GetAllUniteModels()
        {
            var result = await _http.GetFromJsonAsync<List<UniteModel>>("api/unite");
            if (result != null)
                UniteModels = result;

            return UniteModels;
        }
        public async Task<UniteModel> GetUniteById(int id)
        {
            var result = await _http.GetFromJsonAsync<UniteModel>($"api/unite/{id}");
            if (result != null)
                return result;
            else
                throw new Exception("Veri Bulunamadı !");
        }
        public async Task UpdateUnite(UniteModel uniteModel)
        {
            var result = await _http.PutAsJsonAsync($"api/unite/Update/{uniteModel.Id}", uniteModel);
            await SetProses(result);
        }
        private async Task SetProses(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<UniteModel>>();

            UniteModels = response;
             //_navigationManager.NavigateTo("uniteler");
        }
    }
}
