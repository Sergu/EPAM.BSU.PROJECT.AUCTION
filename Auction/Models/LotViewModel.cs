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
        public int? UserSellerId { get; set; }
        public int PrimaryCost { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsActive { get; set; }
        public int? CurrentCost { get; set; }
        public int? UserBetId { get; set; }
        public int? CategoryId { get; set; }
    }
}