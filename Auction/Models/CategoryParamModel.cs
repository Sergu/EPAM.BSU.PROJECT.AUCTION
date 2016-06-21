using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class CategoryParamModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public string CategoryLotsAction { get; set; } 
    }
}