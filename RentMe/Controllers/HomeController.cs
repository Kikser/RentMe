using RentMe.Models;
using RentMe.Models.Enums;
using RentMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentMe.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Rent(string searchBy, string search)
        {
           
            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Rent).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }
        public ActionResult Sale()
        {

            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Sale).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }
    }
}