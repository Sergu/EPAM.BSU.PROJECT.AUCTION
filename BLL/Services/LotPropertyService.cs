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
    public class LotPropertyService : ILotPropertyService
    {
        private readonly IUnitOfWork uow;
        private readonly ILotPropertyRepository lotPropertyRepository;

        public LotPropertyService(IUnitOfWork uow, ILotPropertyRepository repository)
        {
            this.uow = uow;
            this.lotPropertyRepository = repository;
        }
        public IEnumerable<LotPropertyEntity> GetPropertiesByLotId(int lotId)
        {
            return lotPropertyRepository.GetPropertiesByLotId(lotId).Select(prop => prop.ToBllLotProperty());
        }
        public void Create(LotPropertyEntity entity)
        {
            lotPropertyRepository.Create(entity.ToDalLotProperty());
            uow.Commit();
        }
        public void Update(LotPropertyEntity entity)
        {
            lotPropertyRepository.Update(entity.ToDalLotProperty());
            uow.Commit();
        }
        public void Delete(int id)
        {
            lotPropertyRepository.Delete(id);
            uow.Commit();
        }
    }
}
