using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;

namespace BLL.interfaces.Services
{
    public interface IService<TEntity> where TEntity : IBllEntity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
