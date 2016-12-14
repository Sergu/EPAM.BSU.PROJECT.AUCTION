using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repository
{
    public interface IPhotoRepository : IRepository<DalPhoto>
    {
        DalPhoto GetPhotoById(int id);
        int CreatePhoto(DalPhoto entity);
    }
}
