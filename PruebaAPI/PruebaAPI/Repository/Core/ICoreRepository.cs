using System.Linq.Expressions;

namespace PruebaAPI.Repository.Core
{
    public interface ICoreRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetOne(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
