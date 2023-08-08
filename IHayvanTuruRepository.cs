namespace WebUygulama1.Models
{
    public interface IHayvanTuruRepository : IRepository<HayvanTuru>
    {
        void Guncelle(HayvanTuru hayvanturu);
        void Kaydet();
    }
}
