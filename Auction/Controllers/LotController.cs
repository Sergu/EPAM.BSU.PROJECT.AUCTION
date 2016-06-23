using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using PagedList;
using PagedList.Mvc;
using System.Security.Principal;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
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
        private ICategoryService categoryService;
        private ILotMonitoringService lotMonitoringService;
        private IBetHistoryService betService;
        private int pageSize;
        public LotController(IUserService userService,ILotService lotService, ICategoryService categoryService,ILotMonitoringService lotMonitoringService, IBetHistoryService betService)
        {
            this.userService = userService;
            this.lotService = lotService;
            this.categoryService = categoryService;
            this.lotMonitoringService = lotMonitoringService;
            this.betService = betService;
            if (!int.TryParse(ConfigurationManager.AppSettings["pageSize"], out pageSize))
            {
                this.pageSize = 8;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var lotViewModel = ToLotViewModel(lotService.GetLotById(id));
            var model = new DetailsLotModel{
                LotViewModel = lotViewModel
            };
            return View("Details",model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult MakeBet(DetailsLotModel model, int lotId)
        {
            model.LotViewModel = ToLotViewModel(lotService.GetLotById(lotId));
            var user = userService.GetUserByLogin(User.Identity.Name);
            var userSumFromAllLots = lotService.GetUserBetActiveLots(user.Id).Sum(lot => lot.CurrentCost.Value);
            model.Balance = user.Money - userSumFromAllLots;
            if ((ModelState.IsValid)&&(model.LotViewModel.IsActive))
            {
                if(model.Balance >= model.Money)
                {
                    if (model.Money > model.LotViewModel.CurrentCost)
                    {
                        user.Money = user.Money - model.Money;
                        userService.Update(user);
                        var lot = lotService.GetLotById(lotId);
                        lot.CurrentCost = model.Money;
                        lot.UserBetId = user.Id;
                        lotService.Update(lot);

                        var bet = new BetHistoryEntity
                        {
                            Cost = model.Money,
                            date = DateTime.Now,
                            LotId = lot.Id,
                            UserId = user.Id
                        };
                        betService.Create(bet);
                        return RedirectToAction("Details", new { id = lot.Id});
                    }
                }               
            }
            var lotViewModel = ToLotViewModel(lotService.GetLotById(model.LotId));
            model = new DetailsLotModel
            {
                LotViewModel = lotViewModel
            };
            return View("Details", model);
        }
        [Authorize]
        public ActionResult UserWantedLots()
        {
            return View("UserWantedLotsView");
        }
        [Authorize]
        public ActionResult UserBoughtLots()
        {
            return View("UserBoughtLostView");
        }
        public ActionResult UserProposedActiveLots()
        {
            return View("UserProposedActiveLotsView");
        }
        public ActionResult UserProposedSoldLots()
        {
            return View("UserProposedSoldLotsView");
        }

        [Authorize]
        public ActionResult GetUserActiveLots(int? page)
        {
            IIdentity identity = User.Identity;
            UserViewModel user = userService.GetUserByLogin(identity.Name).ToMvcUser();
            IEnumerable<LotViewModel> lots = lotService.GetUserBetActiveLots(user.Id)
                                                            .Select(lot => ToLotViewModel(lot));
            int pageNumber = page ?? 1;
            var model = new GuestPagerModel
            {
                Lots = lots.ToPagedList(pageNumber,pageSize),
                LotsGettingAction = "GetUserActiveLots"
            };

            return PartialView("_LotsViewPartial",model);
        }

        [Authorize]
        public ActionResult GetUserBougthLots(int? page)
        {
            UserViewModel user = userService.GetUserByLogin(User.Identity.Name).ToMvcUser();
            IEnumerable<LotViewModel> lots = lotService.GetUserBetBoughtLots(user.Id)
                                                            .Select(lot => ToLotViewModel(lot));

            int pageNumber = page ?? 1;
            var model = new GuestPagerModel
            {
                Lots = lots.ToPagedList(pageNumber, pageSize),
                LotsGettingAction = "GetUserBougthLots"
            };

            return PartialView("_LotsViewPartial", model);
        }
        [Authorize]
        public ActionResult GetUserProposedActiveLots(int? page)
        {
            UserViewModel user = userService.GetUserByLogin(User.Identity.Name).ToMvcUser();
            var lots = lotService.GetUserSellerActiveLots(user.Id).Select(lot => ToLotViewModel(lot));

            int pageNumber = page ?? 1;
            var model = new GuestPagerModel
            {
                Lots = lots.ToPagedList(pageNumber, pageSize),
                LotsGettingAction = "GetUserProposedActiveLots"
            };

            return PartialView("_LotsViewPartial", model);
        }
        [Authorize]
        public ActionResult GetUserProposedSoldLots(int? page)
        {
            UserViewModel user = userService.GetUserByLogin(User.Identity.Name).ToMvcUser();
            IEnumerable<LotViewModel> lots = lotService.GetUserSellerSoldLots(user.Id).Select(lot => ToLotViewModel(lot));

            int pageNumber = page ?? 1;
            var model = new GuestPagerModel
            {
                Lots = lots.ToPagedList(pageNumber, pageSize),
                LotsGettingAction = "GetUserProposedSoldLots"
            };

            return PartialView("_LotsViewPartial", model);
        }

        public ActionResult ActiveIndex(int? category,string searchString)
        {
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
                lots = lotService.GetAllActiveLots().Select(lot => ToLotViewModel(lot));
            else
                lots = lotService.GetActiveLotsByCategory(category.Value).Select(lot => ToLotViewModel(lot));
            if (searchString != null)
            {
                lots = lots.Where(lot => lot.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            lots = lots.OrderBy(lot => lot.EndDate);

            int pageNumber = page ?? 1;
            GuestPagerModel model = new GuestPagerModel { Lots = lots.ToPagedList(pageNumber, pageSize)
                                                                    , SearchString = searchString
                                                                    , Category = category };

            return PartialView("_LotViewGuestActivePartial", model);
        }

        public ActionResult LotSearchSold(int? category,string searchString,int? page)
        {
            IEnumerable<LotViewModel> lots = null;
            if (category == null)
                lots = lotService.GetAllSoldLots().Select(lot => ToLotViewModel(lot));
            else
                lots = lotService.GetSoldLotsByCategory(category.Value).Select(lot => ToLotViewModel(lot));
            if (searchString != null)
            {
                lots = lots.Where(lot => lot.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            lots = lots.OrderByDescending(lot => lot.EndDate);

            int pageNumber = page ?? 1;
            GuestPagerModel model = new GuestPagerModel{Lots = lots.ToPagedList(pageNumber, pageSize)
                                                                    ,SearchString = searchString
                                                                    ,Category = category
            };

            return PartialView("_LotViewGuestSoldPartial", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            LotCreatingViewModel model = new LotCreatingViewModel();
            model.Categories = categoryService.GetCategoriesForLotCreation().Select(c => c.ToCategoryForLotModel());
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LotCreatingViewModel model){
            if(ModelState.IsValid)
            {              
                model.CurrentCost = model.PrimaryCost;
                UserViewModel user = userService.GetUserByLogin(User.Identity.Name).ToMvcUser();
                model.UserSellerId = user.Id;
                model.IsActive = 1;
                model.BeginDate = DateTime.Now;
                lotService.Create(model.ToBllLot());
                lotMonitoringService.ChangeTimer();
                return RedirectToAction("ActiveIndex");
            }
            model.Categories = categoryService.GetCategoriesForLotCreation().Select(c => c.ToCategoryForLotModel());
            return View(model);
        }

        [NonAction]
        public LotViewModel ToLotViewModel(LotEntity bllEntity)
        {
            var mvcLot = new LotViewModel()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                EndDate = bllEntity.EndDate,
                BeginDate = bllEntity.BeginDate,
                PrimaryCost = bllEntity.PrimaryCost,
                CurrentCost = bllEntity.CurrentCost,
                
            };
            if(bllEntity.IsActive == 1)
                mvcLot.IsActive = true;
            else
                mvcLot.IsActive = false;

            if (ReferenceEquals(bllEntity.UserBetId, null))
                mvcLot.UserBetName = "";
            else
                mvcLot.UserBetName = userService.GetUserById(bllEntity.UserBetId.Value).Login;
            

            mvcLot.UserSellerName = userService.GetUserById(bllEntity.UserSellerId.Value).Login;
            mvcLot.Category = categoryService.GetById(bllEntity.CategoryId.Value).Name;
            mvcLot.betCount = betService.GetBetsByLotId(bllEntity.Id).Count();
            return mvcLot;
        }

    }
}
