using BaseDomain.Interfaces;
using Data.Context;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _dbContext;
        public UnitOfWork(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
