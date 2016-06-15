using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface ILotRepository : IRepository<DalLot>
    {
        //IEnumerable<DalLot> GetAllLots();
        IEnumerable<DalLot> GetAllActiveLots();
        IEnumerable<DalLot> GetUserSellerAllLots(int userSellerId);
        IEnumerable<DalLot> GetUserSellerActiveLots(int userSellerId);
        IEnumerable<DalLot> GetUserSellerSoldLots(int userSellerId);
        IEnumerable<DalLot> GetUserBetAllLots(int userBetId);
        IEnumerable<DalLot> GetUserBetActiveLots(int userBetId);
        IEnumerable<DalLot> GetUserBetBoughtLots(int userBetId);
        IEnumerable<DalLot> GetActiveLotsByCategory(int categoryId);
    }
}
