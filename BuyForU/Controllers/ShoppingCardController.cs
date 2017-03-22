using BuyForU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BuyForU.Controllers
{
    public class ShoppingCardController : Controller
    {
        private BuyForUDB context = new BuyForUDB();

        [HttpGet]
        public ActionResult Card()
        {
            List<Product> itemsToAdd;

            itemsToAdd = context.Products
                .Where(p => p.Status == State.InCard
                && p.User.UserName == User.Identity.Name)
                .ToList();

            return View(itemsToAdd);
        }

        public ActionResult AddToCard(int id)
        {

            Product product;

            product = context.Products
                .Include(p => p.User)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            User user = context.Users
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user != null)
            {
                product.User = context.Users
                    .Where(u => u.ID == user.ID)
                    .FirstOrDefault();

                context.Users.Attach(product.User);
            }

            product.Status = State.InCard;

            product.IsInCard = true;

            context.SaveChanges();

            return RedirectToAction("Home", "Home");
        }

        public decimal RemoveFromCard(int id)
        {
            Product product;

            product = context.Products
                .Include(p => p.User)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            product.UserID = null;

            product.Status = State.ForSale;

            product.IsInCard = false;

            context.SaveChanges();

            return product.Price;
        }

        public ActionResult Sale()
        {
            List<Product> itemsToSale;

            itemsToSale = context.Products
                .Where(p => p.Status == State.InCard 
                && p.User.UserName == User.Identity.Name)
                .ToList();

            foreach (var item in itemsToSale)
            {
                item.Status = State.Sold;
            }

            context.SaveChanges();

            ViewBag.Message = "הקניה בוצעה בהצלחה";

            return RedirectToAction("Home", "Home");
        }
    }
}