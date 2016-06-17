using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class BetHistoryRepository : IBetHistoryRepository
    {
        private readonly DbContext context;
        public BetHistoryRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<DalBetHistory> GetBetsByLotId(int lotId)
        {
            return context.Set<DalBetHistory>()
                .Where(bet => bet.LotId == lotId)
                .Select(bet => new DalBetHistory()
                {
                    Id = bet.Id,
                    date = bet.date,
                    Cost = bet.Cost,
                    LotId = bet.LotId,
                    UserId = bet.UserId
                });
        }
        public void Create(DalBetHistory entity)
        {
            var bet = new BetHistory()
            {
                lot_id = entity.LotId,
                coast = entity.Cost,
                date = entity.date,
                user_id = entity.UserId
            };
            context.Set<BetHistory>().Add(bet);
        }
        public void Update(DalBetHistory entity)
        {
            var bet = context.Set<BetHistory>().FirstOrDefault(b => b.id == entity.Id);
            bet.coast = entity.Cost;
            bet.date = entity.date;
            bet.lot_id = entity.LotId;
            bet.user_id = entity.UserId;
            context.Entry(bet).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var bet = context.Set<BetHistory>().FirstOrDefault(b => b.id == id);
            context.Set<BetHistory>().Remove(bet);
        }
    }
}
