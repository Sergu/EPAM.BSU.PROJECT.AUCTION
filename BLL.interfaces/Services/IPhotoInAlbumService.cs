using BLL.interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Services
{
    public interface IPhotoInAlbumService : IService<PhotoInAlbumEntity>
    {
        IEnumerable<PhotoEntity> GetPhotosInAlbumId(int id);
    }
}
