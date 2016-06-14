using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalLotProperty
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
    }
}
