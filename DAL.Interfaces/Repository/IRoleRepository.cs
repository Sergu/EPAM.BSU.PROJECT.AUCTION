using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetRoleByName(string roleName);
        DalRole GetRoleById(int roleId);
        IEnumerable<DalRole> GetAllRoles();
    }
}
