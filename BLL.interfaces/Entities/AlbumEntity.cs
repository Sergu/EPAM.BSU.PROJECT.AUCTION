using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class AlbumEntity : IBllEntity
    {
        public int Id { get; set; }
        public int Lot_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
