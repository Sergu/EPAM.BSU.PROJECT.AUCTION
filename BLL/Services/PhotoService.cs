using BLL.interfaces.Entities;
using BLL.interfaces.Services;
using DAL.Concrete;
using DAL.Interfaces.Repository;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork uow;
        public PhotoService(IUnitOfWork uow, PhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
            this.uow = uow;
        }
        public PhotoEntity GetPhotoById(int id)
        {
            return photoRepository.GetPhotoById(id).ToBllPhoto();
        }
        public void Create(PhotoEntity entity)
        {
            photoRepository.Create(entity.ToDalPhoto());
            uow.Commit();
        }
        public void Update(PhotoEntity entity)
        {
            photoRepository.Update(entity.ToDalPhoto());
            uow.Commit();
        }
        public void Delete(int id)
        {
            photoRepository.Delete(id);
            uow.Commit();
        }
    }
}
