﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalBetHistory : IEntity
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int? UserId { get; set; }
        public int Cost { get; set; }
        public DateTime date { get; set; }
    }
}
