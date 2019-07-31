using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperts_CPRG214_Final_JayGervais.Models;

namespace TravelExperts_CPRG214_Final_JayGervais.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerLogin
        public ActionResult Login()
        {
            return View();
        }

        // POST:
        [HttpPost]
        public ActionResult Login(CustomerLogin login)
        {
            if (ModelState.IsValid)
            {
                try
                {   
                    int custId = CustomerDB.CustomerLogin(login);
                    if(custId == -1)
                    {
                        ModelState.AddModelError("", "Username or password does not match");
                        return View(login);
                    }
                    else
                    {
                        Session["CustomerId"] = custId;
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Response.AddHeader("Cache-Control", "no-cache, no-store,must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");
                    Response.AddHeader("Expires", "0");
                    Session.Abandon();

                    Session.Clear();
                    Response.Cookies.Clear();
                    Session.RemoveAll();

                    Session["Login"] = null;
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
    
}