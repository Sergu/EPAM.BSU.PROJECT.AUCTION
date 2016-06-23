using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class BetViewModel
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public string UserName { get; set; }
        public int Cost { get; set; }
        public DateTime date { get; set; }
    }
}