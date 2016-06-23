using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Auction.Validators
{
    public class CustomPurchaseMoneyValidator : ValidationAttribute
    {
        private const int maxSum = 99999999;
        //private readonly IUserService userService;
        //public CustomPurchaseMoneyValidator(IUserService userService)
        //{
        //    this.userService = userService;
        //}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
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
        }
    }
}