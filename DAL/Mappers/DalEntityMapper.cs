using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalEntityMapper
    {
        public static DalUser ToDalUser(User userORM)
        {
            return new DalUser
            {
                Id = userORM.id,
                Email = userORM.email,
                Login = userORM.login,
                Money = userORM.money
            };
        }
        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User
            {
                id = dalUser.Id,
                login = dalUser.Login,
                money = dalUser.Money,
                email = dalUser.Email
            };
        }
    }
}
