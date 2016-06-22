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
        public IEnumerable<LotEntity> GetAllSoldLots()
        {
            return lotRepository.GetAllSoldLots().Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetActiveLotsByCategory(int categoryId)
        {
            return lotRepository.GetActiveLotsByCategory(categoryId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetSoldLotsByCategory(int categoryId)
        {
            return lotRepository.GetSoldLotsByCategory(categoryId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetUserBetActiveLots(int userBetId)
        {
            return lotRepository.GetUserBetActiveLots(userBetId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetUserBetBoughtLots(int userBetId)
        {
            return lotRepository.GetUserBetBoughtLots(userBetId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetUserSellerSoldLots(int userSellerId)
        {
            return lotRepository.GetUserSellerSoldLots(userSellerId).Select(lot => lot.ToBllLot());
        }
        public IEnumerable<LotEntity> GetUserSellerActiveLots(int userSellerId)
        {
            return lotRepository.GetUserSellerActiveLots(userSellerId).Select(lot => lot.ToBllLot());
        }
        public void Create(LotEntity entity)
        {
            lotRepository.Create(entity.ToDalLot());
            uow.Commit();
            uow.Dispose();
        }
        public void Update(LotEntity entity)
        {
            lotRepository.Update(entity.ToDalLot());
            uow.Commit();
            uow.Dispose();
        }
        public void Delete(int id)
        {
            lotRepository.Delete(id);
            uow.Commit();
            uow.Dispose();
        }
    }
}
