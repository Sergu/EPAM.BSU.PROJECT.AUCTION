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
    }
}