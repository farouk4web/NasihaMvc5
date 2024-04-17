using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nasiha.Models;
using Nasiha.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nasiha.Controllers
{

    [Authorize(Roles = RoleName.Admins)]
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // Create Admins role
        //public ActionResult CreateAdminRole()
        //{

        //    var adminRole = new IdentityRole
        //    {
        //        Name = RoleName.Admins
        //    };

        //    _context.Roles.Add(adminRole);
        //    _context.SaveChanges();

        //    return RedirectToAction("index", "Home");
        //}


        //// Dashboard 
        public ActionResult Index()
        {
            var advices = _context.Advices.Count();
            var users = _context.Users.Count();

            var adminRole = _context.Roles.SingleOrDefault(m => m.Name == RoleName.Admins);

            var admins = _context.Set<IdentityUserRole>().Count(r => r.RoleId == adminRole.Id);

            DashboardVM viewModel = new DashboardVM
            {
                Advices = advices,
                Admins = admins,
                Users = users,
            };

            return View(viewModel);
        }


        // get All Users
        public ActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }


        // get All Admins
        public ActionResult Admins()
        {
            var AdminRole = _context.Roles.SingleOrDefault(r => r.Name == RoleName.Admins);

            List<ApplicationUser> users = new List<ApplicationUser>();

            foreach (var user in AdminRole.Users)
            {
                var adminUser = _context.Users.Find(user.UserId);
                users.Add(adminUser);
            }

            return View(users);
        }


        // get All Messages
        public ActionResult Advices(string id)
        {
            List<Advice> advices;

            if (id != null)
                advices = _context.Advices.Where(a => a.ReceiverId == id).ToList();
            else
                advices = _context.Advices.ToList();

            return View(advices);
        }

        // add user to admin 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToAdmins(string userId)
        {
            
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Index", "Home");

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.AddToRole(userId, RoleName.Admins);

            var user = _context.Users.Find(userId);

            return RedirectToAction("New", "Advices", new { nickname = user.Nickname });
        }

        //Remove user From Admins
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromAdmins(string userId)
        {
            // if any user (admin Or Client) trying to remove the site Owner User redirect to home page        State :::::   1

            var ownerId = ConfigurationManager.AppSettings["SiteOwnerId"].ToString();

            if (string.IsNullOrEmpty(userId) || userId == ownerId || userId == User.Identity.GetUserId())
                return RedirectToAction("Index", "Home");

            // admin trying to remove any user from admins exept sit owner                                      State :::::   2
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.RemoveFromRole(userId, RoleName.Admins);

            var user = _context.Users.Find(userId);

            return RedirectToAction("New", "Advices", new { nickname = user.Nickname });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmRemoveAccount(string userId)
        {
            // if any user (admin Or Client) trying to remove the site Owner User redirect to home page        State :::::   1
            var ownerId = ConfigurationManager.AppSettings["SiteOwnerId"].ToString();
            if (string.IsNullOrEmpty(userId) || userId == ownerId)
                return RedirectToAction("Index", "Home");

            // admin trying to remove any user exept sit owner                                                State :::::   2
            if (User.IsInRole(RoleName.Admins))
            {

                //remove all msgs had related with this user first
                var advices = _context.Advices.Where(m => m.ReceiverId == userId).ToList();

                foreach (var advice in advices)
                    _context.Advices.Remove(advice);

                _context.SaveChanges();

                // Remove the user for ever
                var user = _context.Users.Find(userId);
                _context.Users.Remove(user);
                _context.SaveChanges();

                // Remove user Image
                // not Necessary at this momment but it will be Necessary on the future when we have many of users

            }
            return RedirectToAction("Users", "Admins");

        }
    
    }
}