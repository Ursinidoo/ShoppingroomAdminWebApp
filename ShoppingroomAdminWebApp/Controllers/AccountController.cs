using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingroomAdminWebApp.Models.Account;

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
            if (pUser.iUsername == null || pUser.iPassword == null)
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















