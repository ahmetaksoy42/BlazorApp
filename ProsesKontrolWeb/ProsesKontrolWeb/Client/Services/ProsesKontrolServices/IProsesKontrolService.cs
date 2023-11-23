using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Client.Services.ProsesKontrolServices
{
    public interface IProsesKontrolService
    {
        List<ProsesKontrolModel> ProsesKontrolModels { get; set; }
        Task<List<ProsesKontrolModel>> GetProsesKontrolModels();
        Task<List<ProsesKontrolModel>> GetProsesKontrolModelsByProsesId(int? prosesId);
        Task<ProsesKontrolModel> GetProsesById(int id);
        Task<ProsesKontrolModel> AddProses(ProsesKontrolModel prosesKontrolModel);
        Task UpdateProses(ProsesKontrolModel prosesKontrolModel);
        Task DeleteProses(int id);
    }
}
