using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auction.Validators;

namespace Auction.Models
{
    public class LotCreatingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Enter lot name") ]
        [Display(Name = "Lot name")]
        public string Name { get; set; }
        public int? UserSellerId { get; set; }

        [Required(ErrorMessage = "Enter primary cost of your lot")]
        [Display(Name = "Primary cost")]
        public int PrimaryCost { get; set; }
        public DateTime BeginDate { get; set; }

        [Required(ErrorMessage="Enter end Date in format dd.mm.yyyy hh:mm")]
        [DisplayFormat(DataFormatString="{0:dd.mm.yy hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [CustomLotEndDateValidator]
        public DateTime EndDate { get; set; }
        public int IsActive { get; set; }
        public int? CurrentCost { get; set; }
        public int? UserBetId { get; set; }
        [Display(Name="Category")]
        public int? CategoryId { get; set; }
        public IEnumerable<CategoryForLotCreationModel> Categories { get; set; }
    }
}