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
    public class PhotoInAlbumRepository : IPhotoInAlbumRepository
    {
        private readonly DbContext context;

        public PhotoInAlbumRepository(DbContext uow)
        {
            this.context = uow;
        }

        public DalPhotoInAlbum GetEntitiesByPhotoInAlbumId(int id)
        {
            return context.Set<PhotoInAlbum>()
                .Where(e => e.Id == id)
                .Select(e => new DalPhotoInAlbum()
                {
                    Id = e.Id,
                    AlbumId = e.Album_Id,
                    PhotoId = e.Photo_Id
                }).FirstOrDefault();
        }

        public IEnumerable<DalPhotoInAlbum> GetEntitiesByAlbumId(int id)
        {
            return context.Set<PhotoInAlbum>()
                .Where(e => e.Album_Id == id)
                .Select(e => new DalPhotoInAlbum()
                {
                    Id = e.Id,
                    AlbumId = e.Album_Id,
                    PhotoId = e.Photo_Id
                });
        }

        public IEnumerable<DalPhotoInAlbum> GetEntitiesByPhotoId(int id)
        {
            return context.Set<PhotoInAlbum>()
                .Where(e => e.Photo_Id == id)
                .Select(e => new DalPhotoInAlbum()
                {
                    Id = e.Id,
                    AlbumId = e.Album_Id,
                    PhotoId = e.Photo_Id
                });
        }

        public void Create(DalPhotoInAlbum entity)
        {
            var photo = new DalPhotoInAlbum()
            {
                AlbumId = entity.AlbumId,
                PhotoId = entity.PhotoId
            };
            context.Set<DalPhotoInAlbum>().Add(photo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var photoInAlbum = context.Set<DalPhotoInAlbum>().FirstOrDefault(e => e.Id == id);

            context.Set<DalPhotoInAlbum>().Remove(photoInAlbum);
            context.SaveChanges();
        }

        public void Update(DalPhotoInAlbum entity)
        {
            var photoInAlbum = context.Set<DalPhotoInAlbum>().FirstOrDefault(e => e.Id == entity.Id);
            photoInAlbum.PhotoId = entity.PhotoId;
            photoInAlbum.AlbumId = entity.AlbumId;
            context.Entry(photoInAlbum).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
