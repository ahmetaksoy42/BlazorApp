using ProsesKontrolWeb.Client.Pages;
using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Client.Services.ImageServices
{
    public interface IImageService
    {
        List<ImageModel> ImageModels { get; set; }
        // List<ImageFile> ImageFiles { get; set; }
        Task<Dictionary<string, string>> GetImageById(int tableId, int tableInsideId);
        Task<List<string>> GetThumbnailData(int tableId, int tableInsideId);
        Task<List<ImageModel>> GetImageModel(int tableId, int tableInsideId);
        Task AddImage(List<ImageFile> file);
        Task DeleteImageByIdAndName(int tableId, int tableInsideId,string name);
        Task DeleteImageById(int tableId, int tableInsideId);
    }
}
