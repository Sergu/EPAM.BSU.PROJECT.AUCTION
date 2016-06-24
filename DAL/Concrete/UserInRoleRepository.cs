using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Concrete
{
    public class UserInRoleRepository : IUserInRoleRepository
    {
        private readonly DbContext context;
        public UserInRoleRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<DalUserInRole> GetUserInRoleByUserId(int userId)
        {
            return context.Set<UserInRole>().Where(r => r.user_id == userId).Select(r => new DalUserInRole
            {
                Id = r.id,
                RoleId = r.role_id,
                UserId = r.user_id
            });
        }
        public IEnumerable<DalUserInRole> GetUserInRoleByRoleId(int roleId)
        {
            return context.Set<UserInRole>().Where(r => r.role_id == roleId).Select(r => new DalUserInRole
            {
                Id = r.id,
                RoleId = r.role_id,
                UserId = r.user_id
            });
        }
        public void Create(DalUserInRole entity)
        {
            var userInRole = new UserInRole
            {
                role_id = entity.RoleId,
                user_id = entity.UserId
            };
            context.Set<UserInRole>().Add(userInRole);
            context.SaveChanges();
        }
        public void Update(DalUserInRole entity)
        {
            var userInRole = context.Set<UserInRole>().FirstOrDefault(r => r.id == entity.Id);
            userInRole.user_id = entity.UserId;
            userInRole.role_id = entity.RoleId;
            context.Entry(userInRole).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var userInRole = context.Set<UserInRole>().FirstOrDefault(r => r.id == id);
            context.Set<UserInRole>().Remove(userInRole);
            context.SaveChanges();
        }
    }
}
