using Leoheat.DAL.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leoheat.DAL.Repository
{
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private LeoheatDbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(LeoheatDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }

       
        public EntityEntry<TEntity> Create(TEntity item)
        {
            return this._dbSet.Add(item);
        }
      
        public EntityEntry<TEntity> Delete(TEntity item)
        {
            return this._dbSet.Remove(item);
        }

        public void Dispose()
        {
            if (this._context!=null)
            {
                _context.Dispose();
            }
        }

        public TEntity Get(int id)
        {
            return this._dbSet.Find(id);
        }

        public IQueryable<TEntity> Read()
        {
            return _dbSet.AsNoTracking();
        }
       
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
