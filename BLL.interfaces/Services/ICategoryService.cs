using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;

namespace BLL.interfaces.Services
{
    public interface ICategoryService : IService<CategoryEntity>
    {
        IEnumerable<CategoryEntity> GetAll();
        IEnumerable<CategoryForLotCreationEntity> GetCategoriesForLotCreation();
        CategoryEntity GetById(int id);
    }
}
