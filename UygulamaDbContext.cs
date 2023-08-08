using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebUygulama1.Models;
// veri tabanında EF Tablo oluşturulması için ilgili model sınıfları buraya eklenir.
namespace WebUygulama1.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {

        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
    
        public DbSet<HayvanTuru> HayvanTurleri { get; set; }    
        
        public DbSet<Hayvan> Hayvanlar { get; set; }

        public DbSet<Sahiplenme> Sahiplenmeler { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers  { get; set; }
    }
    
}
