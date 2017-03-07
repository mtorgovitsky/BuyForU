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
                if (user.UserName != null && user.Password != null)
                {
                    User tmp = context.Users.Where(u => u.UserName == user.UserName
                        && u.Password == user.Password).FirstOrDefault();
                    if (tmp != null)
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie
                            ($"{tmp.FirstName} {tmp.LastName}", true);
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