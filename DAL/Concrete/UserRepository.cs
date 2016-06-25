using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;

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
                .Select(user => new DalUser() {
                    Id = user.id,
                    Login = user.login,
                    Money = user.money,
                    Email = user.email,
                    Password = user.password
                })
                .FirstOrDefault();
        }
        public IEnumerable<DalUser> GetAll()
        {
            IEnumerable<DalUser> col = context.Set<User>()
                .Select(user => new DalUser() { 
                    Id = user.id,
                    Login = user.login,
                    Money = user.money,
                    Email = user.email,
                    Password = user.password
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
                    Email = user.email,
                    Password = user.password
                })
                .FirstOrDefault();
        }
        public void Create(DalUser entity)
        {
            var user = new User
            {
                login = entity.Login,
                money = entity.Money,
                email = entity.Email,
                password = entity.Password
            };
            context.Set<User>().Add(user);
            context.SaveChanges();
        }
        public void Update(DalUser entity)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.id == entity.Id);
            user.login = entity.Login;
            user.money = entity.Money;
            user.email = entity.Email;
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.id == id);
            context.Set<User>().Remove(user);
        }
    }
}
