using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Repositories
{
    public interface IRepository<TEntity>: IDisposable
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(int id);
        void Save(); 
    }
}
