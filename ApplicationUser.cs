using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebUygulama1.Models
{
    public class ApplicationUser : IdentityUser    
    {

        [Required]
        public int Musterino { get; set; }

        public string Adres { get; set; }
       
    }
}
