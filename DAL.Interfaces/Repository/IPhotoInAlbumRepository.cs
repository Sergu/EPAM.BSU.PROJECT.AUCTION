using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repository
{
    public interface IPhotoInAlbumRepository : IRepository<DalPhotoInAlbum>
    {
        IEnumerable<DalPhotoInAlbum> GetEntitiesByAlbumId(int id);

        IEnumerable<DalPhotoInAlbum> GetEntitiesByPhotoId(int id);

        DalPhotoInAlbum GetEntitiesByPhotoInAlbumId(int id);
    }
}
