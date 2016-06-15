using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using Auction.Models;
using Auction.Infrastructure.Mappers;

namespace Auction.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        //
        // GET: /Default/
        public UserController(IUserService repository)
        {
            this.userService = repository;
        }

        public ActionResult GetAllUsers()
        {      
            IEnumerable<UserViewModel> entities = userService.GetAllUserEntities().Select(u => u.ToMvcUser());

            int i = 1;
            return View();
        }

    }
}
