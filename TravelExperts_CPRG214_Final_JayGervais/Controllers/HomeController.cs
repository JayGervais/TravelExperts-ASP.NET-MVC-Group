using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelExperts_CPRG214_Final_JayGervais.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Experience An Unforgettable Adventure";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get In Touch With Us";

            return View();
        }
    }
}