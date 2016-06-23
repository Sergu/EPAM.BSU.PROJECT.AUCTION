using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.interfaces.Entities;
using Auction.Models;

namespace Auction.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Email = userEntity.Email,
                Money = userEntity.Money
            };
        }
        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                Login = userViewModel.Login,
                Money = userViewModel.Money,
                Email = userViewModel.Email
            };
        }
        //public static LotViewModel ToMvcLot(this LotEntity lotEntity)
        //{
        //    return new LotViewModel()
        //    {
        //        Id = lotEntity.Id,
        //        IsActive = lotEntity.IsActive,
        //        Name = lotEntity.Name,
        //        BeginDate = lotEntity.BeginDate,
        //        EndDate = lotEntity.EndDate,
        //        CategoryId = lotEntity.CategoryId,
        //        CurrentCost = lotEntity.CurrentCost,
        //        PrimaryCost = lotEntity.PrimaryCost,
        //        UserBetId = lotEntity.UserBetId,
        //        UserSellerId = lotEntity.UserSellerId
        //    };
        //}
        //public static LotEntity ToBllLot(this LotViewModel lotViewModel)
        //{
        //    return new LotEntity()
        //    {
        //        Id = lotViewModel.Id,
        //        IsActive = lotViewModel.IsActive,
        //        Name = lotViewModel.Name,
        //        BeginDate = lotViewModel.BeginDate,
        //        EndDate = lotViewModel.EndDate,
        //        CategoryId = lotViewModel.CategoryId,
        //        CurrentCost = lotViewModel.CurrentCost,
        //        PrimaryCost = lotViewModel.PrimaryCost,
        //        UserBetId = lotViewModel.UserBetId,
        //        UserSellerId = lotViewModel.UserSellerId
        //    };
        //}
        public static CategoryViewModel ToMvcCategory(this CategoryEntity category){
            return new CategoryViewModel()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                ActiveLotsCount = category.ActiveLotsCount,
                SoldLotsCount = category.SoldLotsCount
            };
        }
        public static CategoryEntity ToBllCategory(this CategoryViewModel category)
        {
            return new CategoryEntity()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                ActiveLotsCount = category.ActiveLotsCount,
                SoldLotsCount = category.SoldLotsCount
            };
        }
        public static CategoryForLotCreationModel ToCategoryForLotModel(this CategoryForLotCreationEntity category)
        {
            return new CategoryForLotCreationModel()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }
        public static LotEntity ToBllLot(this LotCreatingViewModel lot){
            return new LotEntity()
            {
                Id = lot.Id,
                IsActive = lot.IsActive,
                Name = lot.Name,
                BeginDate = lot.BeginDate,
                EndDate = lot.EndDate,
                CategoryId = lot.CategoryId,
                CurrentCost = lot.CurrentCost,
                PrimaryCost = lot.PrimaryCost,
                UserBetId = lot.UserBetId,
                UserSellerId = lot.UserSellerId
            };
        }
    }
}