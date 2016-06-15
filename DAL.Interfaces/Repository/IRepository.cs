using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        //TEntity GetById(int key);
        //TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
