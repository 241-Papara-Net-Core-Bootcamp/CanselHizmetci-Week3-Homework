using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain;

namespace RepositoryPattern.Data.Concretes
{
    public class Repository<T> :IRepository<T> where T :BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().Where(c => !c.IsDeleted).AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(c => !c.IsDeleted).Where(exp).AsQueryable();

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var e = _context.Set<T>().Find(id);
            if (e == null) return;
            e.IsDeleted = true;
            _context.SaveChanges();
        }

        public void HardRemove(int id)
        {
            var e = _context.Set<T>().Find(id);
            if (e == null) return;
            _context.Set<T>().Remove(e);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {

            var e = _context.Set<T>().Find(entity.Id);
            if (e == null) return;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
