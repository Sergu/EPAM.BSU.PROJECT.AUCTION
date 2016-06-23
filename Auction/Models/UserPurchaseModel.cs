using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Auction.Validators;

namespace Auction.Models
{
    public class UserPurchaseModel
    {
        public UserViewModel userModel { get; set; }

        [Required]
        [Display(Name = "Purchase sum")]
        [CustomPurchaseMoneyValidator]
        public int money { get; set; }
    }
}