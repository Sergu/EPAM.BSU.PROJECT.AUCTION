using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IBetHistoryRepository : IRepository<DalBetHistory>
    {
        IEnumerable<DalBetHistory> GetBetsByLotId(int lotId);
    }
}
