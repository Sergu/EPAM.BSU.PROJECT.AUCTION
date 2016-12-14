using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DbContext context;

        public AlbumRepository(DbContext uow)
        {
            this.context = uow;
        }

        public DalAlbum GetAlbumById(int id)
        {
            return context.Set<Album>()
                .Where(e => e.Id == id)
                .Select(e => new DalAlbum()
                {
                    Id = e.Id,
                    Description = e.Description,
                    Name = e.Name,
                    Lot_Id = e.Lot_Id
                }).FirstOrDefault();
        }

        public void Create(DalAlbum entity)
        {
            var album = new Album()
            {
                Description = entity.Description,
                Name = entity.Name,
                Lot_Id = entity.Lot_Id
            };
            context.Set<Album>().Add(album);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var album = context.Set<Album>().FirstOrDefault(e => e.Id == id);

            context.Set<Album>().Remove(album);
            context.SaveChanges();
        }

        public void Update(DalAlbum entity)
        {
            var album = context.Set<Album>().FirstOrDefault(e => e.Id == entity.Id);
            album.Name = entity.Name;
            album.Description = entity.Description;
            album.Lot_Id = entity.Lot_Id;
            context.Entry(album).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<DalAlbum> GetAlbumsByLotId(int lotId)
        {
            return context.Set<Album>()
                .Where(e => e.Lot_Id == lotId)
                .Select(e => new DalAlbum()
                {
                    Id = e.Id,
                    Description = e.Description,
                    Lot_Id = e.Lot_Id,
                    Name = e.Name
                });
        }
    }
}
