using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsesKontrolWeb.Server.Data;
using ProsesKontrolWeb.Shared.Models;
using Syncfusion.Blazor.Data;

namespace ProsesKontrolWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsesKontrolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public int Id;
        public ProsesKontrolController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProsesKontrolModel>>> GetAllProses()
        {
            var prosesKontrols = await _context.ProsesKontrolModels.ToListAsync();
            return Ok(prosesKontrols);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProsesKontrolModel>> GetProsesById(int id)
        {
            var prosesKontrol = await _context.ProsesKontrolModels.Where(a=>a.Id == id).FirstOrDefaultAsync();
       
            return prosesKontrol;
        }
        [HttpGet("Filtre/{prosesId}")]
        public async Task<ActionResult<List<ProsesKontrolModel>>> GetProsesListByProsesId(int prosesId)
        {
            var prosesKontrol = await _context.ProsesKontrolModels.Where(a=>a.ProsesModelId == prosesId).ToListAsync();
       
            return prosesKontrol;
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ProsesKontrolModel>> UpdateProses(ProsesKontrolModel prosesKontrolModel, int id)
        {
            var dbProses = await _context.ProsesKontrolModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbProses == null)
            {
                return NotFound("Proses Bulunamadı");
            }
            dbProses.HataTipi = prosesKontrolModel.HataTipi;
            dbProses.Standart = prosesKontrolModel.Standart;
            dbProses.KontrolMetodu = prosesKontrolModel.KontrolMetodu;
            dbProses.Operator = prosesKontrolModel.Operator;
            dbProses.OperatorKontrol = prosesKontrolModel.OperatorKontrol;
            dbProses.ProsesSorumlusuKontrol = prosesKontrolModel.ProsesSorumlusuKontrol;
            dbProses.ProsesKontrolSorumlusu = prosesKontrolModel.ProsesKontrolSorumlusu;
            dbProses.ProsesModelId = prosesKontrolModel.ProsesModelId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbProses());
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<ProsesKontrolModel>>> DeleteProses(int id)
        {
            var dbProses = await _context.ProsesKontrolModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbProses == null)
            {
                return NotFound("Proses Bulunamadı");
            }
            _context.ProsesKontrolModels.Remove(dbProses);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProses());
        }
        [HttpPost]
        public async Task<ActionResult<List<ProsesKontrolModel>>> AddProses(ProsesKontrolModel prosesKontrolModel)
        {
           _context.ProsesKontrolModels.Add(prosesKontrolModel);
            await _context.SaveChangesAsync();
            return Ok(prosesKontrolModel);
        }
        private async Task<List<ProsesKontrolModel>> GetDbProses()
        {
            return await _context.ProsesKontrolModels.ToListAsync();
        }
        
    }
}
