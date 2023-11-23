using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsesKontrolWeb.Shared.Models
{
    public class ProsesKontrolModel
    {
        public int Id { get; set; }
        public string? HataTipi { get; set; }
        public string? Standart { get; set; }
        public string? KontrolMetodu { get; set; }
        public bool? Operator { get; set; } = false;
        public string? OperatorKontrol { get; set; }
        public bool? ProsesKontrolSorumlusu { get; set; }
        public string? ProsesSorumlusuKontrol { get; set; }
        public int? ProsesModelId { get; set; }
        public ProsesModel? ProsesModel { get; set; }
    }
}
