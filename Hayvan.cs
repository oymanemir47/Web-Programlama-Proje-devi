using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUygulama1.Models
{
    public class Hayvan
    {
        [Key]
        public int Id { get; set; }
        
        
        [Required]
        public string HayvanAdi { get; set; }
        public string Tanim { get; set; }

        [Required]
        public string Cinsiyet { get; set; }
        [Required]
        [Range(10,50000)]

        public double Fiyat { get; set; }

        [ValidateNever]
        public int HayvanTuruId { get; set; }
        [ForeignKey("HayvanTuruId")]
        [ValidateNever]
        public HayvanTuru HayvanTuru { get; set; }

        [ValidateNever]
        public string ResimUrl { get; set; }

    }
}
