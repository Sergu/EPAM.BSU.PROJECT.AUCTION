﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class PhotoInAlbumEntity : IBllEntity
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int PhotoId { get; set; }
    }
}
