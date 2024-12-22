using Donation_Tracker.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Donation_Tracker.EF;

namespace Donation_Tracker.Controllers
{
    public class HomeController : Controller
    {

        Donation_TrackerEntities db = new Donation_TrackerEntities();
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

        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO l) 
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Logins
                            where u.Email.Equals(l.Email) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user.Id;
                TempData["Msg"] = "Login Successfull";
                /*if (user.UserType.Equals("admin"))
                {
                    return RedirectToAction("DeshBoard", "Admin");
                }*/
                return RedirectToAction("DeshBoard", "Employee");
            }
            return View(l);
        }
    }
}