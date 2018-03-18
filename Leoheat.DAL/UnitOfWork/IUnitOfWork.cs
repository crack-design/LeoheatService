using Leoheat.DAL.Entities;
using Leoheat.DAL.Entities.Interfaces;
using Leoheat.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leoheat.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<LeoheatObject> ObjectsRepository { get; }

        int SaveChanges();
    }
}
