using Microsoft.EntityFrameworkCore;
using OyunArkadasim.Utility;
using System.Linq.Expressions;

namespace OyunArkadasim.Models
{
    public class OyunlarimRepository : Repository<Oyunlarim>, IOyunlarimRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public OyunlarimRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Oyunlarim oyunlarim)
        {
            _uygulamaDbContext.Update(oyunlarim);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }


    }
}
