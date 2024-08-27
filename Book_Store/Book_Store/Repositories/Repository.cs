using Book_Store.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book_Store.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BookStoreDBContext _context; 
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BookStoreDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id); 
        }

        public void Insert(TEntity model)
        {
            _dbSet.Add(model);
        }
        public void Update(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}