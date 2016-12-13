using DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using System.Data.Entity;
using ORM;

namespace DAL.Concrete
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext uow)
        {
            this.context = uow;
        }

        public DalPhoto GetPhotoById(int id)
        {
            return context.Set<Photo>()
                .Where(e => e.Id == id)
                .Select(e => new DalPhoto() {
                    Id = e.Id,
                    FilePath = e.FilePath,
                    Name = e.Name
                }).FirstOrDefault();
        }

        public void Create(DalPhoto entity)
        {
            var photo = new Photo()
            {
                FilePath = entity.FilePath,
                Name = entity.Name
            };
            context.Set<Photo>().Add(photo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var photo = context.Set<Photo>().FirstOrDefault(e => e.Id == id);

            context.Set<Photo>().Remove(photo);
            context.SaveChanges();
        }

        public void Update(DalPhoto entity)
        {
            var photo = context.Set<Photo>().FirstOrDefault(e => e.Id == entity.Id);
            photo.Name = entity.Name;
            photo.FilePath = entity.FilePath;
            context.Entry(photo).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
