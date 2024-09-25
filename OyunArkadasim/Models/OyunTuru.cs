using System.ComponentModel.DataAnnotations;

namespace OyunArkadasim.Models
{
    public class OyunTuru
    {
        [Key]
        public int TurId { get; set; }
        public string OyunTuruAdi { get; set; }

      
    }
}
