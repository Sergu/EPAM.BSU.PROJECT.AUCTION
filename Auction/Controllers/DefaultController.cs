using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;

namespace Auction.Controllers
{
    public class DefaultController : Controller
    {
        private IUserService userService;
        //
        // GET: /Default/
        public DefaultController(IUserService repository)
        {
            this.userService = repository;
        }

        public ActionResult Index()
        {
            List<UserEntity> entities = userService.GetAllUserEntities().ToList();

            int i = 1;
            return View();
        }

    }
}
