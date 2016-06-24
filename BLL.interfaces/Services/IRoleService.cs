using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Entities;

namespace BLL.interfaces.Services
{
    public interface IRoleService : IService<RoleEntity>
    {
        RoleEntity GetRoleByName(string roleName);
        RoleEntity GetRoleById(int roleId);
        IEnumerable<RoleEntity> GetAllRoles();
    }
}
