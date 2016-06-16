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
    public class LotService : ILotService
    {
        private readonly IUnitOfWork uow;
        private readonly ILotRepository lotRepository;

        public LotService(IUnitOfWork uow, ILotRepository repository)
        {
            this.uow = uow;
            this.lotRepository = repository;
        }
        public IEnumerable<LotEntity> GetAllActiveLots()
        {
            return lotRepository.GetAllActiveLots().Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetActiveLotsByCategory(int categoryId)
        {
            return lotRepository.GetActiveLotsByCategory(categoryId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetUserBetActiveLots(int userBetId)
        {
            return lotRepository.GetUserBetActiveLots(userBetId).Select(lot => lot.ToBllLot());
        }
    }
}
