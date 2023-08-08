namespace WebUygulama1.Models
{
    public interface IHayvanRepository : IRepository<Hayvan>
    {
        void Guncelle(Hayvan hayvan);
        void Kaydet();
    }
}
