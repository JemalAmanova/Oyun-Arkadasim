namespace OyunArkadasim.Models
{
    public interface IOyunRepository: IRepository<Oyun>
    {
        Oyun GetOyunById(int id);
        void Guncelle(Oyun oyun);
     
        void Kaydet();

    }
}
