using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Auction.Models
{
    public class GuestPagerModel
    {
        public IPagedList<LotViewModel> Lots { get; set; }
        public int? Category { get; set; }
        public string SearchString { get; set; }
    }
}