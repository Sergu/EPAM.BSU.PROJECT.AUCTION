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
    public class LotPropertyRepository : ILotPropertyRepository
    {
        private readonly DbContext context;
        public LotPropertyRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<DalLotProperty> GetPropertiesByLotId(int lotId)
        {
            return context.Set<LotProperty>()
                .Where(prop => lotId == prop.lot_id)
                .Select(prop => new DalLotProperty()
                {
                    Id = prop.id,
                    Property = prop.property,
                    Description = prop.description,
                    LotId = prop.lot_id
                });
        }
        public void Create(DalLotProperty entity)
        {
            var property = new LotProperty()
            {
                lot_id = entity.LotId,
                description = entity.Description,
                property = entity.Property
            };
            context.Set<LotProperty>().Add(property);
        }
        public void Update(DalLotProperty entity)
        {
            var property = context.Set<LotProperty>().FirstOrDefault(prop => prop.id == entity.Id);
            property.lot_id = entity.LotId;
            property.property = entity.Property;
            property.description = entity.Description;
            context.Entry(property).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var property = context.Set<LotProperty>().FirstOrDefault(prop => prop.id == id);
            context.Set<LotProperty>().Remove(property);
        }
    }
}
