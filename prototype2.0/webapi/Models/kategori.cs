using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class kategori
    {
        public int Id { get; set; }
        [Display(Name = "cihaz adı")]
        public string? kategoriAdi { get; set; }
    }
}
