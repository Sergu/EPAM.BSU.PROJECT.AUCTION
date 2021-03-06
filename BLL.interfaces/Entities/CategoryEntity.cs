﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class CategoryEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ActiveLotsCount { get; set; }
        public int SoldLotsCount { get; set; }
    }
}
