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
        public static DalUser ToDalUser(this User userORM)
        {
            return new DalUser
            {
                Id = userORM.id,
                email = userORM.email,
                Login = userORM.login,
                money = userORM.money
            };
        }
        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User
            {
                id = dalUser.Id,
                login = dalUser.Login,
                money = dalUser.money,
                email = dalUser.email
            };
        }
    }
}
