using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class LotPropertyEntity : IBllEntity
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
    }
}
