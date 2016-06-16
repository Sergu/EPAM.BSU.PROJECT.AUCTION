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
    }
}
