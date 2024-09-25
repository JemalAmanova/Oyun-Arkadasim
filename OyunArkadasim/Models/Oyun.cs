using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunArkadasim.Models
{
    public class Oyun
    {

        [Key]
        public int  Id { get; set; }

        [Required (ErrorMessage ="Oyun Adı Boş Bırakılamaz!")]
        [DisplayName("Oyun Adı")]
        public string OyunAdi { get; set; }



        [DisplayName("Oyuncu Sayısı")]
        public int OyuncuSayisi { get; set; }


        [DisplayName("Buluşma Zamanı")]
        public DateTime BulusmaZamani { get; set; }


        [DisplayName("Oyun Türü")]
        [ValidateNever]
        public int TurId { get; set; }
        [ForeignKey("TurId")]

        [ValidateNever]
        public OyunTuru OyunTuru { get; set; }

        [ValidateNever]
        public string ResimUrl { get; set; }

    }
}
