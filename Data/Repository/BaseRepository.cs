using BaseDomain.Interfaces;
using BaseDomain.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    { 
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DataDbContext mySqlContext)
        {
            _dbSet = mySqlContext.Set<TEntity>();
        }

        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TEntity id)
        {
            _dbSet.Update(id);
        }

        public void Delete(Guid id)
        {
            //_mySqlContext.Set<TEntity>().Remove(new TEntity { Id = id });
            _dbSet.Remove(Select(id));
        }

        public IList<TEntity> Select() =>
            _dbSet.ToList();

        public TEntity Select(Guid id) =>
            _dbSet.Find(id);
    }
}
