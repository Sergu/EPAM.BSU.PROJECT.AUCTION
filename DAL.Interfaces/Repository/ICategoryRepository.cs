using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<DalCategory>
    {
        IEnumerable<DalCategory> GetAll();
        DalCategory GetById(int id);

    }
}
