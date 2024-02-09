using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class user
    {
        public int Id { get; set; }
        public string? isim { get; set; }
        public string? mail { get; set; }
        public string? sifre { get; set; }
        public int? telefon { get; set; }
        public rol? rol { get; set; }
    }
}
