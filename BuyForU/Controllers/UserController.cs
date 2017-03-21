using BuyForU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BuyForU.Controllers
{
    public class UserController : Controller
    {
        private BuyForUDB context = new BuyForUDB();

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.UserName == null || user.Password == null)
            {
                var msg = "נא למלות שם משתמש וסיסמה";

                return RedirectToAction("Home", "Home", new { Message = msg, user = user });
            }
            else
            {
                var chkUser = context.Users
                    .Where(u => u.UserName == user.UserName
                    && u.Password == user.Password)
                    .FirstOrDefault();

                if (chkUser != null)
                {
                    FormsAuthentication.SetAuthCookie($"{chkUser.UserName}", true);

                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    var msg = "שם משתמש וסיסמה שגויים";

                    return RedirectToAction("Home", "Home", new { Message = msg });
                }
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Home", "Home");
        }


        [HttpPost]
        public ViewResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    var ExistsUser = context.Users.Where(User => User.UserName == user.UserName).FirstOrDefault();
                    if (ExistsUser == null)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        ViewBag.Message = "פרטי משתמש נקלטו בהצלחה";

                        return View("EditUser");
                    }
                    else
                    {
                        ViewBag.Message = "שם משתמש תפוס";

                        return View("EditUser");
                    }
                }
                else
                {
                    context.Users.AddOrUpdate(user);

                    context.SaveChanges();

                    ViewBag.Message = "העדכון עבר בהצלחה";

                    return View("EditUser");
                }
            }
            return View("EditUser", new User());

        }
        public ActionResult EditUser()
        {
            var user = context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (user != null)
            {
                return View("EditUser", user);
            }
            else
            {
                return View("EditUser", new User());
            }
        }
    }
}