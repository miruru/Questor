using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomain.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(Guid id);

        IList<TEntity> Select();

        TEntity Select(Guid id);
    }
}
