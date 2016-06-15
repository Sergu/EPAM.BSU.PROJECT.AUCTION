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
                .Select(user => DalEntityMapper.ToDalUser(user))
                .FirstOrDefault();
        }
        public IEnumerable<DalUser> GetAll()
        {
            IEnumerable<DalUser> col = context.Set<User>()
                .Select(user => new DalUser() { 
                    Id = user.id,
                    Login = user.login,
                    Money = user.money,
                    Email = user.email                  
                });
            return col;
        }
        public DalUser GetByLogin(string login)
        {
            return context.Set<User>().Where(user => user.login == login)
                .Select(user => new DalUser() {
                    Id = user.id,
                    Login = user.login,
                    Money = user.money,
                    Email = user.email
                })
                .FirstOrDefault();
        }
        public void Create(DalUser entity)
        {
            throw new NotImplementedException();
        }
        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
