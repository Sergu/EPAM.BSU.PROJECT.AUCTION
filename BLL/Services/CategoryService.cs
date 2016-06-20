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
        private readonly ILotRepository lotRepository;

        public CategoryService(IUnitOfWork uow, ICategoryRepository repository, ILotRepository lotRepository)
        {
            this.uow = uow;
            this.categoryRepository = repository;
            this.lotRepository = lotRepository;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            var categories = categoryRepository.GetAll().Select(cat => cat.ToBllCategory());
            List<CategoryEntity> list = categories.ToList();

            for(int i=0;i<list.Count();i++)
            {
                int activeLots = lotRepository.GetActiveLotsByCategory(list[i].Id).Count();
                int soldLots = lotRepository.GetSoldLotsByCategory(list[i].Id).Count();
                list[i].ActiveLotsCount  = activeLots;
                list[i].SoldLotsCount = soldLots;
            }
            return (IEnumerable<CategoryEntity>)list;
        }
        public CategoryEntity GetById(int id)
        {
            var category = categoryRepository.GetById(id).ToBllCategory();
            category.ActiveLotsCount = lotRepository.GetActiveLotsByCategory(id).Count();
            category.SoldLotsCount = lotRepository.GetSoldLotsByCategory(id).Count();
            return category;           
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
