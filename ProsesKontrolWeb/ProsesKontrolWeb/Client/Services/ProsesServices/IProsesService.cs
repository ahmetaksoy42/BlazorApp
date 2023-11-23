using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Client.Services.ProsesServices
{
    public interface IProsesService
    {
        List<ProsesModel> ProsesModels { get; set; }
        Task<List<ProsesModel>> GetAllProsesModels();
        Task<ProsesModel> GetProsesById(int id);
        Task<List<ProsesModel>> GetProsesModelsByUniteId(int? uniteId);

        Task<ProsesModel> AddProses(ProsesModel prosesModel);
        Task UpdateProses(ProsesModel prosesModel);
        Task DeleteProses(int id);
    }
}
