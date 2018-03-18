using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leoheat.DAL.Entities.Interfaces;
using Leoheat.DAL.Repository;
using Leoheat.DAL.Entities;

namespace Leoheat.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LeoheatDbContext _context;
        private IRepository<LeoheatObject> _objectRepository;
        public UnitOfWork(LeoheatDbContext context, IRepository<LeoheatObject> repo)
        {
            this._context = context;
            this._objectRepository = repo;
        }

        public IRepository<LeoheatObject> ObjectsRepository =>  _objectRepository;

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
