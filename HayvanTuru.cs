


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUygulama1.Models
{
    public class HayvanTuru
    {
        [Key] // primary key
        public int Id { get; set; }

        [Required(ErrorMessage ="Hayvan Türü Adı Boş Bırakılamaz!")] // not null
        [MaxLength(25)]
        [DisplayName("Hayvan Türü Adı")]
        public string Ad { get; set; }
    }
}
