using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IUserInRoleRepository : IRepository<DalUserInRole>
    {
        IEnumerable<DalUserInRole> GetUserInRoleByUserId(int userId);
        IEnumerable<DalUserInRole> GetUserInRoleByRoleId(int roleId);
    }
}
