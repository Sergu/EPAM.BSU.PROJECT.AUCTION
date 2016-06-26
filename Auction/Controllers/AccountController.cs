using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Auction.Models;
using System.Security.Principal;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using Auction.Infrastructure.Mappers;
using Auction.Providers;

namespace Auction.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        private IUserService userService;
        private IPaymentServiceProvider paymentService;

        public AccountController(IUserService userService, IPaymentServiceProvider paymentService)
        {
            this.userService = userService;
            this.paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult Room()
        {
            var user = userService.GetUserByLogin(User.Identity.Name).ToMvcUser();
            var model = new UserPurchaseModel
            {
                userModel = user
            };
            return View("Room", model);
        }
        [HttpPost]
        public ActionResult Room(UserPurchaseModel model)
        {
            var user = userService.GetUserByLogin(User.Identity.Name);
            if (ModelState.IsValid)
            {
                paymentService.PurchaseMoney(user, model.money);
                return RedirectToAction("Room", "Account");
            }
            model.money = 0;
            model.userModel = user.ToMvcUser();
            return View("Room", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                if (Membership.ValidateUser(model.login, model.Password))
                {
                    var user = userService.GetUserByLogin(model.login);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(model.login, model.RememberMe, 20);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("About", "Home");
                }
            }

            ModelState.AddModelError("", "Incorrect login or password");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session[FormsAuthentication.FormsCookieName] = null;

            return RedirectToAction("About", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserEntity()
                {
                    Login = model.login,
                    Email = model.email,
                    Password = model.Password,
                };

                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(user);
                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.login, false);
                    return RedirectToAction("About", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error. This login already taken");
                }
            }

            return View(model);
        }

    }
}
