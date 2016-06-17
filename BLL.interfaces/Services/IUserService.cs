using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;

namespace BLL.interfaces.Services
{
    public interface IUserService : IService<UserEntity>
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        UserEntity GetUserByLogin(string login);
    }
}
