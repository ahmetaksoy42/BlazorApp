using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsesKontrolWeb.Shared.Models
{
    public class ProsesModel
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string? Aciklama { get; set; }
        public string? Birim{ get; set; }
        public DateTime? KalipAyarSuresi{ get; set; }
        public DateTime? IsSuresi{ get; set; }
        public int? SaatlikUretimMiktari { get; set; }
        public int? UniteModelId { get; set; }
        public UniteModel? UniteModel { get; set; }
    }
}
