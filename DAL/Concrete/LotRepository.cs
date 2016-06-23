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
    public class LotRepository : ILotRepository
    {
        private readonly DbContext context;

        public LotRepository(DbContext uow)
        {
            this.context = uow;
        }

        //public IEnumerable<DalLot> GetAllLots()
        //{
        //    return context.Set<Lot>()
        //        .Select(lot => new DalLot()
        //        {
        //            Id = lot.id,
        //            Name = lot.name,
        //            PrimaryCost = lot.primaryCoast,
        //            BeginDate = lot.beginDate,
        //            EndDate = lot.endDate,
        //            UserSellerId = lot.user_seller_id,
        //            UserBetId = lot.user_bet_id,
        //            CurrentCost = lot.currentCoast,
        //            CategoryId = lot.category_id,
        //            IsActive = lot.isActive
        //        });
        //}
        public IEnumerable<DalLot> GetAllActiveLots()
        {
            return context.Set<Lot>()
                .Where(lot=>lot.isActive == 1)
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetAllSoldLots()
        {
            return context.Set<Lot>()
                .Where(lot => lot.isActive == 0)
                .Select(lot => new DalLot(){
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetUserSellerAllLots(int userSellerId)
        {
            return context.Set<Lot>()
                .Where(lot => lot.user_seller_id == userSellerId)
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetUserSellerActiveLots(int userSellerId)
        {
            return context.Set<Lot>()
                .Where(lot => (lot.user_seller_id == userSellerId) && (lot.isActive == 1))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetUserSellerSoldLots(int userSellerId)
        {
            return context.Set<Lot>()
                .Where(lot => (lot.user_seller_id == userSellerId) && (lot.isActive == 0))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetUserBetAllLots(int userBetId)
        {
            return context.Set<Lot>()
                .Where(lot => lot.user_bet_id == userBetId)
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetActiveLotsByCategory(int categoryId)
        {
            return context.Set<Lot>()
                .Where(lot => (lot.category_id == categoryId) && (lot.isActive == 1))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetSoldLotsByCategory(int categoryId)
        {
            return context.Set<Lot>()
                .Where(lot => ((lot.category_id == categoryId) && (lot.isActive == 0)))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
                
        }
        public IEnumerable<DalLot> GetUserBetActiveLots(int userBetId)
        {
            return context.Set<Lot>()
                .Where(lot => (lot.user_bet_id == userBetId)&&(lot.isActive == 1))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public IEnumerable<DalLot> GetUserBetBoughtLots(int userBetId)
        {
            return context.Set<Lot>()
                .Where(lot => (lot.user_bet_id == userBetId) && (lot.isActive == 0))
                .Select(lot => new DalLot()
                {
                    Id = lot.id,
                    Name = lot.name,
                    PrimaryCost = lot.primaryCoast,
                    BeginDate = lot.beginDate,
                    EndDate = lot.endDate,
                    UserSellerId = lot.user_seller_id,
                    UserBetId = lot.user_bet_id,
                    CurrentCost = lot.currentCoast,
                    CategoryId = lot.category_id,
                    IsActive = lot.isActive
                });
        }
        public DalLot GetLotById(int id)
        {
            var lot = context.Set<Lot>().FirstOrDefault(l => l.id == id);
            return new DalLot()
            {
                Id = lot.id,
                Name = lot.name,
                PrimaryCost = lot.primaryCoast,
                BeginDate = lot.beginDate,
                EndDate = lot.endDate,
                UserSellerId = lot.user_seller_id,
                UserBetId = lot.user_bet_id,
                CurrentCost = lot.currentCoast,
                CategoryId = lot.category_id,
                IsActive = lot.isActive
            };
        }

        public void Create(DalLot entity)
        {
            var lot = new Lot(){
                name = entity.Name,
                primaryCoast = entity.PrimaryCost,
                beginDate = entity.BeginDate,
                endDate = entity.EndDate,
                user_seller_id = entity.UserSellerId,
                user_bet_id = entity.UserBetId,
                currentCoast = entity.CurrentCost,
                category_id = entity.CategoryId,
                isActive = entity.IsActive
            };
            context.Set<Lot>().Add(lot);
            context.SaveChanges();
            //context.Dispose();
        }
        public void Delete(int id)
        {
            var lot = context.Set<Lot>().FirstOrDefault(l => l.id == id);

            context.Set<Lot>().Remove(lot);
            context.SaveChanges();
        }
        public void Update(DalLot entity)
        {
            var lot = context.Set<Lot>().FirstOrDefault(l => l.id == entity.Id);
            lot.name = entity.Name;
            lot.primaryCoast = entity.PrimaryCost;
            lot.beginDate = entity.BeginDate;
            lot.endDate = entity.EndDate;
            lot.user_seller_id = entity.UserSellerId;
            lot.user_bet_id = entity.UserBetId;
            lot.currentCoast = entity.CurrentCost;
            lot.category_id = entity.CategoryId;
            lot.isActive = entity.IsActive;
            context.Entry(lot).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
