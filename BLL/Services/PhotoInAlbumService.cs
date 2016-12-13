using BLL.interfaces.Entities;
using BLL.interfaces.Services;
using DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoInAlbumService : IPhotoInAlbumService
    {
        private readonly IPhotoInAlbumRepository photoInAlbumRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork uow;
        public PhotoInAlbumService(IUnitOfWork uow, IPhotoInAlbumRepository photoInAlbumRepository, IPhotoRepository photoRepository)
        {
            this.photoInAlbumRepository = photoInAlbumRepository;
            this.photoRepository = photoRepository;
            this.uow = uow;
        }
        public IEnumerable<PhotoEntity> GetPhotosInAlbumId(int id)
        {
            var photosInAlbum = photoInAlbumRepository.GetEntitiesByAlbumId(id).Select(e => e.ToBllPhotoInAlbum());
            List<PhotoEntity> photos = new List<PhotoEntity>();

            foreach(var photoInAlbum in photosInAlbum)
            {
                PhotoEntity photo = photoRepository.GetPhotoById(photoInAlbum.PhotoId).ToBllPhoto();
                photos.Add(photo);
            }

            return photos;
        }
        public void Create(PhotoInAlbumEntity entity)
        {
            photoInAlbumRepository.Create(entity.ToDalPhotoInAlbum());
            uow.Commit();
        }
        public void Update(PhotoInAlbumEntity entity)
        {
            photoInAlbumRepository.Update(entity.ToDalPhotoInAlbum());
            uow.Commit();
        }
        public void Delete(int id)
        {
            photoInAlbumRepository.Delete(id);
            uow.Commit();
        }
    }
}
