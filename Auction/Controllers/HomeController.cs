﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult About()
        {

            return View();
        }
    }
}
