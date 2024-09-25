using Microsoft.EntityFrameworkCore;
using OyunArkadasim.Utility;
using System.Linq.Expressions;

namespace OyunArkadasim.Models
{
    public class OyunTuruRepository : Repository<OyunTuru>, IOyunTuruRepository
    {

        private UygulamaDbContext _uygulamaDbContext;
        public OyunTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(OyunTuru oyunTuru)
        {
            _uygulamaDbContext.Update(oyunTuru);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}