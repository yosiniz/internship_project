using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class urun
    {
        public int Id { get; set; }
        public int serino { get; set; }
        public string? resim { get; set; }
        public string? CihazAdi { get; set; }
        public double fiyat { get; set; }
        public int stok { get; set; }
        public string? ozellik { get; set; }
        public string? durum { get; set; }
        public kategori? kategori { get; set; }
    }
}
