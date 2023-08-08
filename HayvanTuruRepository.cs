using WebUygulama1.Utility;

namespace WebUygulama1.Models
{
    public class HayvanTuruRepository : Repository<HayvanTuru>, IHayvanTuruRepository
    {
        private readonly UygulamaDbContext _uygulamaDbContex;


        public HayvanTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContex = uygulamaDbContext;
        }

        public void Guncelle(HayvanTuru hayvanTuru)
        {
            _uygulamaDbContex.Update(hayvanTuru);
        }

        public void Kaydet()
        {
            _uygulamaDbContex.SaveChanges();
        }
    }
}
