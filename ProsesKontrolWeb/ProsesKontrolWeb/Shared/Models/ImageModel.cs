using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProsesKontrolWeb.Shared.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? UniqueStrId { get; set; }
        public string? FileExtension { get; set; }
        public string? FileLocation { get; set; }
        public int? TableId { get; set; }
        public int TableInsideId { get; set; }
    }
}
