using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class LotViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserSellerName { get; set; }
        public int PrimaryCost { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int? CurrentCost { get; set; }
        public string UserBetName { get; set; }
        public int betCount { get; set; }
        public string Category { get; set; }
    }
}