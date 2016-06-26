using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;

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
            return context.Set<BetHistory>()
                .Where(bet => bet.lot_id == lotId)
                .Select(bet => new DalBetHistory()
                {
                    Id = bet.id,
                    date = bet.date,
                    Cost = bet.coast,
                    LotId = bet.lot_id,
                    UserId = bet.user_id
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
            context.SaveChanges();
        }
        public void Update(DalBetHistory entity)
        {
            var bet = context.Set<BetHistory>().FirstOrDefault(b => b.id == entity.Id);
            bet.coast = entity.Cost;
            bet.date = entity.date;
            bet.lot_id = entity.LotId;
            bet.user_id = entity.UserId;
            context.Entry(bet).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var bet = context.Set<BetHistory>().FirstOrDefault(b => b.id == id);
            context.Entry(bet).State = EntityState.Deleted;
            //context.SaveChanges();
        }
    }
}
