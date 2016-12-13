using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalPhotoInAlbum : IEntity
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int PhotoId { get; set; }
    }
}
