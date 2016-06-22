using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces.Repository;
using DAL.Interfaces.DTO;
using ORM;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext context;
        public CategoryRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<DalCategory> GetAll()
        {
            return context.Set<Category>().Select(category => new DalCategory()
            {
                Id = category.id,
                name = category.name,
                description = category.description
            });
        }
        public DalCategory GetById(int id)
        {
            var category = context.Set<Category>().FirstOrDefault(cat => cat.id == id);
            return new DalCategory()
            {
                Id = category.id,
                description = category.description,
                name = category.name
            };
        }
        public void Create(DalCategory entity)
        {
            var category = new Category()
            {
                name = entity.name,
                description = entity.description
            };
            context.Set<Category>().Add(category);
        }
        public void Update(DalCategory entity)
        {
            var category = context.Set<Category>().FirstOrDefault(cat => cat.id == entity.Id);
            category.name = entity.name;
            category.description = entity.description;
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = context.Set<Category>().FirstOrDefault(cat => cat.id == id);

            context.Set<Category>().Remove(category);
        }
    }
}
