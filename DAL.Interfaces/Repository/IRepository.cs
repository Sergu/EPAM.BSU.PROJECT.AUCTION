﻿using System;
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
        IEnumerable<TEntity> GetAll();
        //TEntity GetById(int key);
        //TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);
        void Create(TEntity e);
        //void Delete(TEntity e);
        void Update(TEntity entity);
    }
}
