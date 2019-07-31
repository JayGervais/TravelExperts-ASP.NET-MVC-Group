using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperts_CPRG214_Final_JayGervais.Models;

namespace TravelExperts_CPRG214_Final_JayGervais.Controllers
{
    public class PackageController : Controller
    {
        List<Package> packages = null;

        // GET: Packages
        public ActionResult Packages()
        {
            packages = PackageDB.GetPackages();
            return View(packages);
        }

    }
}