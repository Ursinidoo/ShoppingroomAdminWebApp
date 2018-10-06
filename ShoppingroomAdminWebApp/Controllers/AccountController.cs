using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingroomAdminWebApp.Models.Account;
using ShoppingroomAdminWebApp.Core;

namespace ShoppingroomAdminWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User pUser)
        {
            KorisnikService tkorisnikService = new KorisnikService();
            Boolean tIsAuthSuccess = tkorisnikService.authenticate(pUser.iUsername, pUser.iPassword);

            if (!tIsAuthSuccess)
            {
                ModelState.AddModelError("pInvalidUserData", "Invalid username or password");
                return View("Login");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Testing()
        {
            return View();
        }
    }
}















