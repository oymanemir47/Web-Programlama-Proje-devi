using WebUygulama1.Utility;

namespace WebUygulama1.Models
{
    public class HayvanRepository : Repository<Hayvan>, IHayvanRepository
    {
        private readonly UygulamaDbContext _uygulamaDbContex;


        public HayvanRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContex = uygulamaDbContext;
        }

        public void Guncelle(Hayvan hayvan)
        {
            _uygulamaDbContex.Update(hayvan);
        }

        public void Kaydet()
        {
            _uygulamaDbContex.SaveChanges();
        }
    }
}
