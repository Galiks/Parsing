using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visual.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ILetyShopsDAO letyShops = new LetyShopsDAO();

            var result = letyShops.GetDiscounts().ToList();

            return View(result);
        }

        
    }
}