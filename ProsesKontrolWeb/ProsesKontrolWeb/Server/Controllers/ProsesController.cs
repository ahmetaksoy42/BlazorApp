using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsesKontrolWeb.Server.Data;
using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProsesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<ProsesModel>>> AddProses(ProsesModel prosesModel)
        {
            _context.ProsesModels.Add(prosesModel);
            await _context.SaveChangesAsync();
            return Ok(prosesModel);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProsesModel>>> GetAllProses()
        {
            var prosesModels = await _context.ProsesModels.ToListAsync();
            return Ok(prosesModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProsesModel>> GetProsesById(int id)
        {
            var proses = await _context.ProsesModels.Where(a => a.Id == id).FirstOrDefaultAsync();

            return proses;
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ProsesModel>> UpdateProses(ProsesModel prosesModel, int id)
        {
            var dbProses = await _context.ProsesModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbProses == null)
            {
                return NotFound("Proses Bulunamadı");
            }
            dbProses.Isim = prosesModel.Isim;
            dbProses.SaatlikUretimMiktari = prosesModel.SaatlikUretimMiktari;
            dbProses.Birim= prosesModel.Birim;
            dbProses.IsSuresi= prosesModel.IsSuresi;
            dbProses.Aciklama= prosesModel.Aciklama;
            dbProses.KalipAyarSuresi= prosesModel.KalipAyarSuresi;
     
            await _context.SaveChangesAsync();

            return Ok(await GetDbProses());
        }
        [HttpGet("Filtre/{uniteId}")]
        public async Task<ActionResult<List<ProsesModel>>> GetProsesListByProsesId(int uniteId)
        {
            var proses = await _context.ProsesModels.Where(a => a.UniteModelId == uniteId).ToListAsync();

            return proses;
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<ProsesModel>>> DeleteProses(int id)
        {
            var dbProses = await _context.ProsesModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbProses == null)
            {
                return NotFound("Proses Bulunamadı");
            }
            _context.ProsesModels.Remove(dbProses);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProses());
        }
        private async Task<List<ProsesModel>> GetDbProses()
        {
            return await _context.ProsesModels.ToListAsync();
        }
    }
}
