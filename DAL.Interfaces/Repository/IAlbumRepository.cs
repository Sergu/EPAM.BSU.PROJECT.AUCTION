using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repository
{
    public interface IAlbumRepository : IRepository<DalAlbum>
    {
        DalAlbum GetAlbumById(int id);
        IEnumerable<DalAlbum> GetAlbumsByLotId(int lotId);
    }
}
