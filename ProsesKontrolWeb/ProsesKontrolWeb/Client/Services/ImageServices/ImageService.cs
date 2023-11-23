using Microsoft.AspNetCore.Components;
using ProsesKontrolWeb.Client.Pages;
using ProsesKontrolWeb.Shared.Models;
using Syncfusion.Blazor.PdfViewer.Internal;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProsesKontrolWeb.Client.Services.ImageServices
{
    public class ImageService : IImageService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<ImageModel> ImageModels { get; set; }
        public List<string> ImageDatas { get; set; }
        Dictionary<string, string> imageTableDictionary = new Dictionary<string, string>();

        public ImageService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task AddImage(List<ImageFile> filesBase64)
        {
            //var result = await _http.PostAsJsonAsync("api/Image", imageModel);
            // await SetImage(result); 
            //------
            // var response = await result.Content.ReadFromJsonAsync<ImageModel>();
            using (var msg = await _http.PostAsJsonAsync<List<ImageFile>>("/api/Image", filesBase64, System.Threading.CancellationToken.None))
            {
                if (msg.IsSuccessStatusCode)
                {
                    filesBase64.Clear();
                }
            }
        }
        public async Task<Dictionary<string,string>> GetImageById(int tableId,int tableInsideId) // tableId de eklenecek parametre olarak // Dic ten Liste çevir sonradan.
        {
            var result = await _http.GetFromJsonAsync<Dictionary<string,string>>($"api/Image/{tableId}/{tableInsideId}");
            if (result != null)
            {
                imageTableDictionary = result;
                return imageTableDictionary;
            }
            else
                throw new Exception("Veri Bulunamadı !");
        }
        public async Task<List<string>> GetThumbnailData(int tableId,int tableInsideId) // tableId de eklenecek parametre olarak // Dic ten Liste çevir sonradan.
        {
            var result = await _http.GetFromJsonAsync<List<string>>($"api/Image/StrId/{tableId}/{tableInsideId}");
            if (result != null)
            {
                return result;
            }
            else
                throw new Exception("Veri Bulunamadı !");
        } 
        public async Task<List<ImageModel>> GetImageModel(int tableId,int tableInsideId) // tableId de eklenecek parametre olarak // Dic ten Liste çevir sonradan.
        {
            var result = await _http.GetFromJsonAsync<List<ImageModel>>($"api/Image/StrId/{tableId}/{tableInsideId}");
            if (result != null)
            {
                return result;
            }
            else
                throw new Exception("Veri Bulunamadı !");
        }
        public async Task DeleteImageByIdAndName(int tableId,int tableInsideId, string imageName)
        {
            var response = await _http.DeleteAsync($"api/Image/Delete/{tableId}/{tableInsideId}/{imageName}");
            //SetImage(response,tableInsideId);

            //// Sayfa yenilenmesi için geçici çözüm
            
            _navigationManager.NavigateTo($"veriler/edit/");
            _navigationManager.NavigateTo($"veriler/edit/{tableInsideId}");
            
            ////////////////////////////////////////
            
            //var result = await _http.DeleteAsync($"api/Image/Delete/{tableInsideId}/{imageName}");
            // checkbox oluşturup her checkbox a o resmin ismini tag olarak ver silerken ona göre silsin
           
        } 
        public async Task DeleteImageById(int tableId ,int tableInsideId)
        {
            var response = await _http.DeleteAsync($"api/Image/Delete/{tableId}/{tableInsideId}");
            //var result = await _http.DeleteAsync($"api/Image/Delete/{tableInsideId}/{imageName}");
            // checkbox oluşturup her checkbox a o resmin ismini tag olarak ver silerken ona göre silsin
        }
       
        private async Task SetImage(HttpResponseMessage result,int id)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ImageModel>>();

            ImageModels = response;
            _navigationManager.NavigateTo($"veriler/edit/{id}");
        }
    }
}
