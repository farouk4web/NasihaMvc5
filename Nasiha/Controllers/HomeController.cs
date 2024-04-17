using Nasiha.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Nasiha.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            // get models for this action
            var users = context.Users.Where(m => m.FullName.Contains(q) || m.Nickname.Contains(q)).ToList();
            return View(users);
        }

        public ActionResult ChangeLanguge(string lang, string returnUrl)
        {
            // change the languge and the culture of site 
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

                // assign new value on cookie with "Language" key
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                Response.Cookies.Add(cookie);
            }


            // return to home Page
            if (returnUrl == null)
                return RedirectToAction("Index");

            return Redirect(returnUrl);
        }

    }
}