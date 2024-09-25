using System.Linq.Expressions;

namespace OyunArkadasim.Models
{

    //  Repository Design Pattern
    public interface IRepository<T> where T : class
    {
        //klass yerine geçecek Törnegin:oyub türüveya oyunlarin yerine geçebilir.
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);
        void Ekle(T entity);
        void Sil(T entity);
        void SilAralik(IEnumerable<T> entities);
    }
}