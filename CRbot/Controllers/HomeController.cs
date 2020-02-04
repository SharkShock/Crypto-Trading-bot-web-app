using CRbot.Controllers.Filters;
using CRbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;


namespace CRbot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }

            var loginDate = Session["LoginDate"];
            return View();
        }
        public ActionResult Contact()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();

            //-----------------
        }
        // Login action
        [HttpGet]
        public ActionResult Login()
        {
            Session["UserTheme"] = "1";
            return View();
        }
        // Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            
            if (ModelState.IsValid)
            {
                using (db dc = new db())
                {
                    var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoginDate"] = DateTime.Now.ToString();
                        Session["UserID"] = v.Id.ToString();
                        Session["LogedUsername"] = v.Username.ToString();
                        //Session["UserTheme"] = v.Theme.ToString();

                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }
        // logout
        public ActionResult LogOut(User u)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            Session.Clear();
            FormsAuthentication.SignOut();

            return View();
        }

        //--------------

        public ActionResult Robots()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Trade()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        //--------------

        public ActionResult Settings()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult SettingsStyle()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Theme(string SelectedId)
        {

            Session["UserTheme"] = SelectedId;
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View("SettingsStyle");
        }

        //mess everywhere  :~)

        public ActionResult SettingsPrivacy()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Market()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Binance()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        //=================================
    }

}