using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using DAL.Interfaces.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class BetHistoryService : IBetHistoryService
    {
        private readonly IUnitOfWork uow;
        private readonly IBetHistoryRepository betRepository;

        public BetHistoryService(IUnitOfWork uow, IBetHistoryRepository betRepository)
        {
            this.uow = uow;
            this.betRepository = betRepository;
        }
        public IEnumerable<BetHistoryEntity> GetBetsByLotId(int lotId)
        {
            return betRepository.GetBetsByLotId(lotId).Select(bet => bet.ToBllBetHistory());
        }
        public void Create(BetHistoryEntity entity)
        {
            betRepository.Create(entity.ToDalBetHistory());
            uow.Commit();
        }
        public void Update(BetHistoryEntity entity)
        {
            betRepository.Update(entity.ToDalBetHistory());
            uow.Commit();
        }
        public void Delete(int id)
        {
            betRepository.Delete(id);
            uow.Commit();
        }
    }
}
