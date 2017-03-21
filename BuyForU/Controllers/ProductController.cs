using BuyForU.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyForU.Controllers
{
    public class ProductController : Controller
    {
        BuyForUDB context = new BuyForUDB();

        [Authorize]
        public ActionResult SubmitData()
        {
            return View("AddProduct", new Product());
        }

        [Authorize]
        [HttpPost]
        public ActionResult SubmitData(Product p)
        {
            HttpFileCollectionWrapper wrapper = HttpContext.Request.Files as HttpFileCollectionWrapper;

            p.Picture1 = GetByteArray(wrapper[0]);
            p.Picture2 = GetByteArray(wrapper[1]);
            p.Picture3 = GetByteArray(wrapper[2]);

            if (ModelState.IsValid)
            {
                User user = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user != null)
                {
                    p.Owner = context.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                    context.Users.Attach(p.Owner);
                }
                p.Date = DateTime.Now;
                context.Products.Add(p);
                context.SaveChanges();
                ViewBag.Message = "File uploaded successfully";

                return RedirectToAction("Home", "Home");


            }

            return View("AddProduct");
        }

        private static byte[] GetByteArray(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && file.ContentType.StartsWith("image"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);

                    byte[] array = ms.GetBuffer();

                    return array;
                }
            }

            return null;
        }
    }
}