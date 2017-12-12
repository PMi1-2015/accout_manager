using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountSystem.Data
{
    abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AccountSystemContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AccountSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object key)
        {
            T entity = _dbSet.Find(key);
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByKey(object key)
        {
            return _dbSet.Find(key);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
