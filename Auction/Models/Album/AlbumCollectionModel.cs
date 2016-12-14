using BLL.interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models.Album
{
    public class AlbumCollectionModel
    {
        public int LotId { get; set; }
        public string LotName { get; set; }

        public IEnumerable<AlbumEntity> Albums { get; set; }
    }
}