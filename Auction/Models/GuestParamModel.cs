using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class GuestParamModel
    {
        public int? Category { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }
    }
}