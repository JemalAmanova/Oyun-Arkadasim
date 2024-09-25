namespace OyunArkadasim.Models
{
    public interface IOyunlarimRepository: IRepository<Oyunlarim>
    {
        void Guncelle(Oyunlarim oyunlarim);
     
        void Kaydet();

    }
}
