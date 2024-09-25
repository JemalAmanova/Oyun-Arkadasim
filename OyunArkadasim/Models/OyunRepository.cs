using Microsoft.EntityFrameworkCore;
using OyunArkadasim.Utility;
using System.Linq.Expressions;

namespace OyunArkadasim.Models
{
    public class OyunRepository : Repository<Oyun>, IOyunRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public OyunRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public Oyun GetOyunById(int id)
        {
            return _uygulamaDbContext.Oyunlar.Find(id);
        }

        public void Guncelle(Oyun oyun)
        {
            _uygulamaDbContext.Update(oyun);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
