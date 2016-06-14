using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }
        public DalUser GetById(int id)
        {
            return context.Set<User>()
                .Where(user => user.id == id)
                .Select(user => user)
                .FirstOrDefault()
                .ToDalUser();
        }
        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => user.ToDalUser());
        }
        public DalUser GetByLogin(string login)
        {
            return context.Set<User>().Where(user => user.login == login)
                .Select(user => user.ToDalUser())
                .FirstOrDefault();
        }
    }
}
