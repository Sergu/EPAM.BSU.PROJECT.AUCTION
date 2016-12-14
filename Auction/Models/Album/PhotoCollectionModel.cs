using BLL.interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models.Album
{
    public class PhotoCollectionModel
    {
        string LotName { get; set; }
        AlbumEntity Album { get; set; }
        IEnumerable<PhotoEntity> Photos { get; set; }
    }
}