namespace OyunArkadasim.Models
{
    public interface IOyunTuruRepository: IRepository<OyunTuru>
    {
        void Guncelle(OyunTuru oyunTuru);
        void Kaydet();

    }
}
