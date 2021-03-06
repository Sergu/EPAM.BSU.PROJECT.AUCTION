﻿using BLL.interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Services
{
    public interface IAlbumService : IService<AlbumEntity>
    {
        AlbumEntity GetAlbomById(int id);
        IEnumerable<AlbumEntity> GetAlbumsByLotId(int lotId);
    }
}
