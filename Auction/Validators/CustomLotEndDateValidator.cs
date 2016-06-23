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
                    if (date < DateTime.Now)
                        return new ValidationResult("End Date should be more than current time. Date format yyyy:mm:dd hh:mm:{ss}");
                    return new ValidationResult("Lot can't be sold for more than two years. Date format yyyy:mm:dd hh:mm:{ss}");
                }
            }
            else
            {
                return new ValidationResult("Incorrect date format required: yyyy:mm:dd hh:mm:{ss}");
            }
        }
    }
}