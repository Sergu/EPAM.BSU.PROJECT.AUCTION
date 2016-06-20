using System;
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
        public ActionResult GetUserActiveLots()
        {
            string name = HttpContext.Profile.UserName;
            IIdentity identity = User.Identity;
            UserViewModel user = userService.GetUserByLogin(identity.Name).ToMvcUser();
            IEnumerable<LotViewModel> lots = lotService.GetUserBetActiveLots(user.Id)
                                                            .Select(lot => lot.ToMvcLot());

            return View(lots);
        }

        [Authorize]
        public ActionResult GetUserBougthLots()
        {
            return View();

        }

        public ActionResult ActiveIndex(int? category,string searchString)
        {
            //ViewBag.SearchString = searchString;
            //ViewBag.Category = category;
            //ViewBag.IsActive = true;
            var param = new GuestParamModel() { Category = category,SearchString = searchString};

            return View("GuestActiveLots",param);
        }
        public ActionResult SoldIndex(int? category,string searchString)
        {
            //ViewBag.Category = category;
            //ViewBag.SearchString = searchString;
            //ViewBag.Category = category;
            var guestLotViewModel = new GuestParamModel(){Category = category,SearchString = searchString};
            return View("GuestSoldLots",guestLotViewModel);
        }

        public ActionResult LotSearchActive(int? category, string searchString,int? page)
        {
            IEnumerable<LotViewModel> lots = null;
            if (category == null)
                lots = lotService.GetAllActiveLots().Select(lot => lot.ToMvcLot());
            else
                lots = lotService.GetActiveLotsByCategory(category.Value).Select(lot => lot.ToMvcLot());
            if (searchString != null)
            {
                lots = lots.Where(lot => lot.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            lots = lots.OrderBy(lot => lot.EndDate);

            return PartialView("_LotViewPartial", lots);
        }

        public ActionResult LotSearchSold(int? category,string searchString,int? page)
        {
            IEnumerable<LotViewModel> lots = null;
            if (category == null)
                lots = lotService.GetAllSoldLots().Select(lot => lot.ToMvcLot());
            else
                lots = lotService.GetSoldLotsByCategory(category.Value).Select(lot => lot.ToMvcLot());
            if (searchString != null)
            {
                lots = lots.Where(lot => lot.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            lots = lots.OrderByDescending(lot => lot.EndDate);

            return PartialView("_LotViewPartial", lots);
        }


        public ActionResult Create()
        {
            LotViewModel model = new LotViewModel
            {
                Name = "new lot",
                UserSellerId = userService.GetUserByLogin(User.Identity.Name).ToMvcUser().Id,
                PrimaryCost = 200,
                IsActive = 1,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            lotService.Create(model.ToBllLot());

            return View();
        }

    }
}
