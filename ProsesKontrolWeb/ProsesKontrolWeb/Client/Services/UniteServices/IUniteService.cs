using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Client.Services.UniteServices
{
    public interface IUniteService
    {
        List<UniteModel> UniteModels { get; set; }
        Task<List<UniteModel>> GetAllUniteModels();
        Task<UniteModel> GetUniteById(int id);
        Task<UniteModel> AddUnite(UniteModel uniteModel);
        Task UpdateUnite(UniteModel uniteModel);
        Task DeleteUnite(int id);
    }
}
