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
                money = userEntity.money,
                email = userEntity.email
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                money = dalUser.money,
                email = dalUser.email
            };
        }
    }
}
