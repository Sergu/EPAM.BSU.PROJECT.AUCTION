using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class PhotoEntity : IBllEntity
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
    }
}
