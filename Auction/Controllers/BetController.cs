using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using Auction.Models;
using Auction.Infrastructure.Mappers;

namespace Auction.Controllers
{
    public class BetController : Controller
    {
        private IBetHistoryService betService;
        private IUserService userService;

        public BetController(IBetHistoryService betService, IUserService userService)
        {
            this.betService = betService;
            this.userService = userService;
        }

        [Authorize]
        public ActionResult LotBets(int lotId)
        {
            var model = betService.GetBetsByLotId(lotId).Select(bet => ToBetViewModel(bet)).OrderBy(bet => bet.date);
            return PartialView("_betPartialView", model);
        }
        [NonAction]
        public BetViewModel ToBetViewModel(BetHistoryEntity bllEntity)
        {
            var mvcBet = new BetViewModel(){
                Id = bllEntity.Id,
                Cost = bllEntity.Cost,
                date = bllEntity.date, 
            };
            if (ReferenceEquals(bllEntity.UserId, null))
                mvcBet.UserName = "";
            else
                mvcBet.UserName = userService.GetUserById(bllEntity.UserId.Value).Login;
            return mvcBet;
        }

    }
}
