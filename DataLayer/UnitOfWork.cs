using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private Repository repo;
        private VehiclesContext dbContext;
        public UnitOfWork(VehiclesContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Repository Repo
        {
            get
            {
                if (repo == null)
                    repo = new Repository(dbContext);
                return repo;
            }
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
