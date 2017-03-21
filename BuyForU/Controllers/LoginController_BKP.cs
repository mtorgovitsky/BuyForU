using BuyForU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyForU.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DB context = new DB())
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    User checkUser = context.Users.Where(u => u.UserName == user.UserName
                        && u.Password == user.Password).FirstOrDefault();
                    if (checkUser != null)
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie
                            ($"{checkUser.FirstName} {checkUser.LastName}", true);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}