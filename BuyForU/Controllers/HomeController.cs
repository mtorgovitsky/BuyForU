using BuyForU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BuyForU.Controllers
{
    public class HomeController : Controller
    {
        private BuyForUDB context = new BuyForUDB();
        private const string jpgMimeType = "image/jpg";

        public ActionResult Home(string msg)
        {
            if (msg != null)
            {
                ViewBag.Message = msg;
            }

            List<Product> list;

            try
            {
                list = context.Products.Where(p => p.Status != State.Sold).ToList();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            return View(list);
        }

        public ActionResult ShowOnHome(int id)
        {
            var image = context.Products
                .Where(p => p.ID == id
                && p.Picture1 != null
                && p.Status != State.Sold)
                .FirstOrDefault();

            if (image != null)
            {
                return File(image.Picture1, jpgMimeType);
            }

            return View();
        }

        public ActionResult OrderByTitle()
        {
            List<Product> products;

            products = context.Products
                .Where(p => p.Status != State.Sold)
                .OrderBy(p => p.Title)
                .ToList();

            return View("Home", products);
        }

        public ActionResult OrderByDate()
        {
            List<Product> products;

            products = context.Products
                .Where(p => p.Status != State.Sold)
                .OrderBy(p => p.Date)
                .ToList();

            return View("Home", products);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Product prdDetails;

            prdDetails = context.Products
                .Include(p => p.Owner)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(prdDetails);
        }

        public ActionResult ShowSecondPicture(int id)
        {
            var imageData = context.Products
                .Where(p => p.ID == id 
                && p.Picture2 != null)
                .FirstOrDefault();

            return File(imageData.Picture2, jpgMimeType);
        }

        public ActionResult ShowThirdPicture(int id)
        {
            var imageData = context.Products
                .Where(p => p.ID == id 
                && p.Picture3 != null)
                .FirstOrDefault();

            return File(imageData.Picture3, jpgMimeType);
        }


    }
}