using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunArkadasim.Models
{
    public class Oyunlarim
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ValidateNever]
        public int OyunId { get; set; }
        [ForeignKey("OyunId")]

        [ValidateNever]
        public  Oyun Oyun {get; set;}

    }
}
