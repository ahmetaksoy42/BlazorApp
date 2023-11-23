using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProsesKontrolWeb.Server.Controllers;
using ProsesKontrolWeb.Shared;
using ProsesKontrolWeb.Shared.Models;
using Syncfusion.Blazor;

namespace ProsesKontrolWeb.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProsesKontrolModel>().HasData(
            //    new ProsesKontrolModel
            //    {
            //        Id = 1,
            //        HataTipi = "1",
            //        Standart = "Standart",
            //        KontrolMetodu = "KM",
            //        Operator = true,
            //        OperatorKontrol = "sda",
            //        ProsesKontrolSorumlusu = false,
            //        ProsesSorumlusuKontrol = "sdasda",
            //    });
        }
        public DbSet<ProsesKontrolModel>? ProsesKontrolModels { get; set; }
        public DbSet<ImageModel>? ImageModels { get; set; }
        public DbSet<ProsesModel>? ProsesModels { get; set;}
        public DbSet<UniteModel>? UniteModels { get; set;}
    }
}
