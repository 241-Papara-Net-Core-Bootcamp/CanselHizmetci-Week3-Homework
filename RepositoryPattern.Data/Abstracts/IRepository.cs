using System.Linq.Expressions;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> Get();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        public void Add(T entity);
        public void Remove(int id);  
        public void HardRemove(int id);
        public void Update(T entity);
    }
}
