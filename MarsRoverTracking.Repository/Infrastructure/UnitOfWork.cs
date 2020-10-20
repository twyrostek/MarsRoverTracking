using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MarsRoverTracking.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoverEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new RoverEntities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }

}