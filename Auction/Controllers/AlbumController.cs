using Auction.Models.Album;
using BLL.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class AlbumController : Controller
    {
        private IUserService userService;
        private IAlbumService albumService;
        private IPhotoInAlbumService photoInAlbumService;
        private IPhotoService photoService;
        private ILotService lotService;

        public AlbumController(IUserService userService, IAlbumService albumService, IPhotoInAlbumService photoInAlbumService, IPhotoService photoService, ILotService lotService)
        {
            this.userService = userService;
            this.albumService = albumService;
            this.photoInAlbumService = photoInAlbumService;
            this.photoService = photoService;
            this.lotService = lotService;
        }

        public ActionResult Albums(int lotId)
        {
            var albums = albumService.GetAlbumsByLotId(lotId);
            var lot = lotService.GetLotById(lotId);

            var model = new AlbumCollectionModel()
            {
                LotId = lot.Id,
                LotName = lot.Name,
                Albums = albums
            };

            return View("AlbumCollectionView",model);
        }

        public ActionResult Photos(int albumId)
        {
            var album = albumService.GetAlbomById(albumId);
            var lot = lotService.GetLotById(album.Lot_Id);

            var photosInAlbum = photoInAlbumService.GetPhotosInAlbumId(album.Id);

            return View();
        }

    }
}
