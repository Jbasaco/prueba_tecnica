using Microsoft.EntityFrameworkCore;
using PruebaAPI.Helpers;
using System.Linq.Expressions;

namespace PruebaAPI.Repository.Core
{
    public abstract class CoreRepositoryImpl<T> : ICoreRepository<T> where T : class
    {
        protected DataContext DataContext { get; set; }

        public CoreRepositoryImpl(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public T Create(T entity)
        {
            DataContext.Set<T>().Add(entity);
            DataContext.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            DataContext.Set<T>().Update(entity);
            DataContext.SaveChanges();

            return entity;

        }
        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);

            DataContext.SaveChanges();
        }


        public IQueryable<T> GetAll() => DataContext.Set<T>().AsNoTracking();

        public IQueryable<T> GetOne(Expression<Func<T, bool>> expression) => DataContext.Set<T>().Where(expression).AsNoTracking();
    }
}
