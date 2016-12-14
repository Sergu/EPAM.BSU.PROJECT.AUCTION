using BLL.interfaces.Entities;
using BLL.interfaces.Services;
using BLL.Mappers;
using DAL.Concrete;
using DAL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoInAlbumRepository photoInAlbumRepository;
        private readonly IUnitOfWork uow;
        public AlbumService(IUnitOfWork uow, AlbumRepository albumRepository, PhotoInAlbumRepository photoInAlbumRepository)
        {
            this.albumRepository = albumRepository;
            this.photoInAlbumRepository = photoInAlbumRepository;
            this.uow = uow;
        }
        public AlbumEntity GetAlbomById(int id)
        {
            return albumRepository.GetAlbumById(id).ToBllAlbum();
        }

        public void Create(AlbumEntity entity)
        {
            albumRepository.Create(entity.ToDalAlbum());
            uow.Commit();
        }
        public void Update(AlbumEntity entity)
        {
            albumRepository.Update(entity.ToDalAlbum());
            uow.Commit();
        }
        public void Delete(int id)
        {
            albumRepository.Delete(id);
            uow.Commit();
        }

        public IEnumerable<AlbumEntity> GetAlbumsByLotId(int lotId)
        {
            return albumRepository.GetAlbumsByLotId(lotId).Select(e => e.ToBllAlbum());
        }
    }
}
