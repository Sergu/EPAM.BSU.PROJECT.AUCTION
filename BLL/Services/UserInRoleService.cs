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
    public class UserInRoleService : IUserInRoleService
    {
        private readonly IUserInRoleRepository userInRoleRepository;
        private readonly IUnitOfWork uow;
        public UserInRoleService(IUnitOfWork uow, IUserInRoleRepository userInRoleRepository)
        {
            this.userInRoleRepository = userInRoleRepository;
            this.uow = uow;
        }
        public IEnumerable<UserInRoleEntity> GetUserInRoleByUserId(int userId)
        {
            return userInRoleRepository.GetUserInRoleByUserId(userId).Select(r => r.ToBllUserInRole());
        }
        public IEnumerable<UserInRoleEntity> GetUserInRoleByRoleId(int roleId)
        {
            return userInRoleRepository.GetUserInRoleByRoleId(roleId).Select(r => r.ToBllUserInRole());
        }
        public void Create(UserInRoleEntity entity)
        {
            userInRoleRepository.Create(entity.ToDalUserInRole());
            uow.Commit();
        }
        public void Update(UserInRoleEntity entity)
        {
            userInRoleRepository.Update(entity.ToDalUserInRole());
            uow.Commit();
        }
        public void Delete(int id)
        {
            userInRoleRepository.Delete(id);
            uow.Commit();
        }

    }
}
