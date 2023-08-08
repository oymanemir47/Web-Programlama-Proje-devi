namespace WebUygulama1.Models
{
    public interface ISahiplenmeRepository : IRepository<Sahiplenme>
    {
        
        void Guncelle(Sahiplenme sahiplenme);
        void Kaydet();
    }
}
