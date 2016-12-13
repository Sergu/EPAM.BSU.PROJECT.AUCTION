using BLL.interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Services
{
    public interface IPhotoService : IService<PhotoEntity>
    {
        PhotoEntity GetPhotoById(int id);
    }
}
