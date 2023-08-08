using WebUygulama1.Utility;

namespace WebUygulama1.Models
{
    public class SahiplenmeRepository : Repository<Sahiplenme>, ISahiplenmeRepository
    {
        private readonly UygulamaDbContext _uygulamaDbContex;


        public SahiplenmeRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContex = uygulamaDbContext;
        }

        public void Guncelle(Sahiplenme sahiplenme)
        {
            _uygulamaDbContex.Update(sahiplenme);
        }

        public void Kaydet()
        {
            _uygulamaDbContex.SaveChanges();
        }
    }
}
