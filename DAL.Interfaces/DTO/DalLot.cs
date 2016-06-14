using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalLot : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserSellerId { get; set; }
        public int PrimaryCost { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int? CurrentCost { get; set; }
        public int UserBetId { get; set; }
    }
}
