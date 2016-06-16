﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using BLL.interfaces.Services;
using Auction.Models;
using Auction.Infrastructure.Mappers;

namespace Auction.Controllers
{
    public class LotController : Controller
    {
        //
        // GET: /Lot/
        private IUserService userService;
        private ILotService lotService;
        public LotController(IUserService userService,ILotService lotService)
        {
            this.userService = userService;
            this.lotService = lotService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLots()
        {
            return View();
        }
        [Authorize]
        public ActionResult GetUserLot()
        {
            string name = HttpContext.Profile.UserName;
            IIdentity identity = User.Identity;
            UserViewModel user = userService.GetUserByLogin(identity.Name).ToMvcUser();
            IEnumerable<LotViewModel> lots = lotService.GetUserBetActiveLots(user.Id)
                                                            .Select(lot => lot.ToMvcLot());
            

            return View();
        }
        public ActionResult GetLot(int id)
        {

            return View();
        }

    }
}
