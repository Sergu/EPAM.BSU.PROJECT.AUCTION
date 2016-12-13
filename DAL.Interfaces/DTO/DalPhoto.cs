﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
    }
}
