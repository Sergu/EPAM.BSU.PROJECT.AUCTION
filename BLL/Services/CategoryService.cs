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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(IUnitOfWork uow, ICategoryRepository repository)
        {
            this.uow = uow;
            this.categoryRepository = repository;
        }
        public IEnumerable<CategoryEntity> GetAll()
        {
            return categoryRepository.GetAll().Select(cat => cat.ToBllCategory());
        }
        public CategoryEntity GetById(int id)
        {
            return categoryRepository.GetById(id).ToBllCategory();
        }
        public void Create(CategoryEntity entity)
        {
            categoryRepository.Create(entity.ToDalCategory());
            uow.Commit();
        }
        public void Update(CategoryEntity entity)
        {
            categoryRepository.Update(entity.ToDalCategory());
            uow.Commit();
        }
        public void Delete(int id)
        {
            categoryRepository.Delete(id);
            uow.Commit();
        }
    }
}
