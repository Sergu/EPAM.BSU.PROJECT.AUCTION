using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;

namespace BLL.interfaces.Services
{
    public interface ILotService
    {
        IEnumerable<LotEntity> GetAllActiveLots();
        IEnumerable<LotEntity> GetActiveLotsByCategory(int categoryId);
        IEnumerable<LotEntity> GetUserBetActiveLots(int userBetId);
    }
}
