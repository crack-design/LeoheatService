using Leoheat.DAL.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leoheat.DAL.Repository
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class, IEntity
    {
        IQueryable<TEntity> Read();

        TEntity Get(int id);

        EntityEntry<TEntity> Create(TEntity item);

        void Update(TEntity item);

        EntityEntry<TEntity> Delete(TEntity item);
    }
}
