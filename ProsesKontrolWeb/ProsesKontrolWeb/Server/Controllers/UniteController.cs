using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsesKontrolWeb.Server.Data;
using ProsesKontrolWeb.Shared.Models;

namespace ProsesKontrolWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UniteController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<UniteModel>>> AddUnite(UniteModel uniteModel)
        {
            _context.UniteModels.Add(uniteModel);
            await _context.SaveChangesAsync();
            return Ok(uniteModel);
        }
        [HttpGet]
        public async Task<ActionResult<List<UniteModel>>> GetAllUnites()
        {
            var uniteModels = await _context.UniteModels.ToListAsync();
            return Ok(uniteModels);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UniteModel>> GetUniteById(int id)
        {
            var unite = await _context.UniteModels.Where(a => a.Id == id).FirstOrDefaultAsync();

            return unite;
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<UniteModel>> UpdateUnit(UniteModel uniteModel, int id)
        {
            var dbUnite = await _context.UniteModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbUnite == null)
            {
                return NotFound("Unit Bulunamadı");
            }
            dbUnite.Isim = uniteModel.Isim;
            dbUnite.KosulNo = uniteModel.KosulNo;
            //şuanlık sadece name var
            await _context.SaveChangesAsync();

            return Ok(await GetDbUnite());
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<UniteModel>>> DeleteUnit(int id)
        {
            var dbUnit = await _context.UniteModels.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (dbUnit == null)
            {
                return NotFound("Unit Bulunamadı");
            }
            _context.UniteModels.Remove(dbUnit);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUnite());
        }
        private async Task<List<UniteModel>> GetDbUnite()
        {
            return await _context.UniteModels.ToListAsync();
        }
    }
}
