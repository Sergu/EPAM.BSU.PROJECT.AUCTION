using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Money = userEntity.Money,
                Email = userEntity.Email
            };
        }
        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Money = dalUser.Money,
                Email = dalUser.Email
            };
        }
        public static LotEntity ToBllLot(this DalLot dallot)
        {
            return new LotEntity()
            {
                Id = dallot.Id,
                IsActive = dallot.IsActive,
                Name = dallot.Name,
                BeginDate = dallot.BeginDate,
                EndDate = dallot.EndDate,
                CategoryId = dallot.CategoryId,
                CurrentCost = dallot.CurrentCost,
                PrimaryCost = dallot.PrimaryCost,
                UserBetId = dallot.UserBetId,
                UserSellerId = dallot.UserSellerId
            };
        }
        public static DalLot ToDalLot(this LotEntity lotEntity)
        {
            return new DalLot()
            {
                Id = lotEntity.Id,
                IsActive = lotEntity.IsActive,
                Name = lotEntity.Name,
                BeginDate = lotEntity.BeginDate,
                EndDate = lotEntity.EndDate,
                CategoryId = lotEntity.CategoryId,
                CurrentCost = lotEntity.CurrentCost,
                PrimaryCost = lotEntity.PrimaryCost,
                UserBetId = lotEntity.UserBetId,
                UserSellerId = lotEntity.UserSellerId
            };
        }
        public static DalCategory ToDalCategory(this CategoryEntity categoryEntity)
        {
            return new DalCategory()
            {
                Id = categoryEntity.Id,
                name = categoryEntity.Name,
                description = categoryEntity.Description
            };
        }
        public static CategoryEntity ToBllCategory(this DalCategory dalCategory)
        {
            return new CategoryEntity()
            {
                Id = dalCategory.Id,
                Name = dalCategory.name,
                Description = dalCategory.description
            };
        }
        public static LotPropertyEntity ToBllLotProperty(this DalLotProperty dalLotProp)
        {
            return new LotPropertyEntity()
            {
                Id = dalLotProp.Id,
                Description = dalLotProp.Description,
                LotId = dalLotProp.LotId,
                Property = dalLotProp.Property
            };
        }
        public static DalLotProperty ToDalLotProperty(this LotPropertyEntity lotPropertEntity)
        {
            return new DalLotProperty()
            {
                Id = lotPropertEntity.Id,
                Description = lotPropertEntity.Description,
                LotId = lotPropertEntity.LotId,
                Property = lotPropertEntity.Property
            };
        }
        public static DalBetHistory ToDalBetHistory(this BetHistoryEntity betEntity)
        {
            return new DalBetHistory()
            {
                Id = betEntity.Id,
                LotId = betEntity.LotId,
                date = betEntity.date,
                Cost = betEntity.Cost,
                UserId = betEntity.UserId
            };
        }
        public static BetHistoryEntity ToBllBetHistory(this DalBetHistory dalBet)
        {
            return new BetHistoryEntity()
            {
                Id = dalBet.Id,
                date = dalBet.date,
                Cost = dalBet.Cost,
                LotId = dalBet.LotId,
                UserId = dalBet.UserId
            };
        }
        public static CategoryForLotCreationEntity ToCategoryForLot(this CategoryEntity category)
        {
            return new CategoryForLotCreationEntity()
            {
                Id = category.Id,
                CategoryName = category.Name
            };
        }
        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }
        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }
        public static UserInRoleEntity ToBllUserInRole(this DalUserInRole dalUserInRole)
        {
            return new UserInRoleEntity
            {
                Id = dalUserInRole.Id,
                RoleId = dalUserInRole.RoleId,
                UserId = dalUserInRole.UserId
            };
        }
        public static DalUserInRole ToDalUserInRole(this UserInRoleEntity bllUserInRole)
        {
            return new DalUserInRole
            {
                Id = bllUserInRole.Id,
                RoleId = bllUserInRole.RoleId,
                UserId = bllUserInRole.UserId
            };
        }
    }
}
