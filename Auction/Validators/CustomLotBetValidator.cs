using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Auction.Models;

namespace Auction.Validators
{
    public class CustomLotBetValidator : ValidationAttribute
    {
        private const int maxSum = 99999999;
        //private readonly IUserService userService;
        //public CustomPurchaseMoneyValidator(IUserService userService)
        //{
        //    this.userService = userService;
        //}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var money = (int)value;
                if ((money < maxSum) && (money > 0))
                {
                    //var user = userService.GetUserByLogin(HttpContext.Current.User.Identity.Name);
                    //if((user.Money + money) < int.MaxValue)
                    return ValidationResult.Success;
                    //return new ValidationResult("money overlow");
                }
                else
                {
                    return new ValidationResult("max len 8, positive number, bet should be more than last bet");
                }
            }
            return new ValidationResult("max len 8, positive number, bet should be more than last bet");
            //if (value != null)
            //{
            //    var model = (int)value;
            //    if((model.Money < maxSum) && (model.Money > 0)){
            //        if(model.Balance >= model.Money){
            //            if(model.Money > model.LotViewModel.CurrentCost)
            //                return ValidationResult.Success;
            //            return new ValidationResult("bet should be more than current cost of the lot");
            //        }
            //        else{
            //            return new ValidationResult(string.Format("not enought money. balance: {0}", model.Balance));
            //        }
            //    }

            //    else{
            //        return new ValidationResult("max len 8 and positive number");
            //    }
            //}
            //return new ValidationResult("max len 8 and positive number");
        }
    }
}