using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;
        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<DalRole> GetAllRoles()
        {
            return context.Set<Role>().Select(r => new DalRole
            {
                Id = r.id,
                Name = r.role1
            });
        }
        public DalRole GetRoleByName(string roleName)
        {
            return context.Set<Role>()
                .Where(r => r.role1.ToUpper() == roleName.ToUpper())
                .Select(r => new DalRole
                {
                    Id = r.id,
                    Name = r.role1
                }).FirstOrDefault();
        }
        public DalRole GetRoleById(int roleId)
        {
            return context.Set<Role>()
                .Where(r => r.id == roleId)
                .Select(r => new DalRole
                {
                    Id = r.id,
                    Name = r.role1
                }).FirstOrDefault();
        }
        public void Create(DalRole dalRole)
        {
            var role = new Role{
                role1 = dalRole.Name
            };
            context.Set<DalRole>().Add(dalRole);
            context.SaveChanges();
        }
        public void Update(DalRole dalRole)
        {
            var role = context.Set<Role>().FirstOrDefault(r => dalRole.Id == r.id);
            role.role1 = dalRole.Name;
            context.Entry(role).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var role = context.Set<Role>().FirstOrDefault(r => r.id == id);
            context.Set<Role>().Remove(role);
            context.SaveChanges();
        }
    }
}
