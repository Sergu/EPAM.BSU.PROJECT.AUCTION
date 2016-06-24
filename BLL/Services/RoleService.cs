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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork uow;
        public RoleService(IUnitOfWork uow, IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
            this.uow = uow;
        }
        public RoleEntity GetRoleByName(string roleName)
        {
            return roleRepository.GetRoleByName(roleName).ToBllRole();
        }
        public RoleEntity GetRoleById(int roleId)
        {
            return roleRepository.GetRoleById(roleId).ToBllRole();
        }
        public IEnumerable<RoleEntity> GetAllRoles()
        {
            return roleRepository.GetAllRoles().Select(r => r.ToBllRole());
        }
        public void Create(RoleEntity entity){
            roleRepository.Create(entity.ToDalRole());
            uow.Commit();
        }
        public void Update(RoleEntity entity){
            roleRepository.Update(entity.ToDalRole());
            uow.Commit();
        }
        public void Delete(int id){
            roleRepository.Delete(id);
            uow.Commit();
        }
    }
}
