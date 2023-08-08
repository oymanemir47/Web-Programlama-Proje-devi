using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUygulama1.Models
{
    public class Sahiplenme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MusteriId { get; set; }

        [ValidateNever]
        public int HayvanId { get; set; }
        [ForeignKey("HayvanId")]

        [ValidateNever]
        public Hayvan Hayvan { get; set; }
    }
}
