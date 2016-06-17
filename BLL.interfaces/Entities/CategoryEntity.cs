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
        public string name { get; set; }
        public string description { get; set; }
    }
}
