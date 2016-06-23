using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.Models;
using System.ComponentModel.DataAnnotations;
using Auction.Validators;

namespace Auction.Models
{
    public class DetailsLotModel
    {
        public LotViewModel LotViewModel {get;set;}

        [Required]
        [Display(Name="Bet")]
        [CustomLotBetValidator]
        public int Money { get; set; }
        public int LotId { get; set; }
        public int Balance { get; set; }
    }
}