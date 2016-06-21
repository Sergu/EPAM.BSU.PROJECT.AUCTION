using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.Validators
{
    public class CustomLotEndDateValidator : ValidationAttribute  
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                DateTime lastDate = DateTime.Now.AddYears(2);
                if ((date < lastDate) && (date > DateTime.Now  /*DateTime.Now.AddMonths(1)*/))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    //return new ValidationResult("Lot can't be exposed for more than two years and his torg duration should be more than 1 month  ");
                    return new ValidationResult("Lot can't be exposed for more than two years");
                }
            }
            else
            {
                return new ValidationResult("Incorrect date format");
            }
        }
    }
}