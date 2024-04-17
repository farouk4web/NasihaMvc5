using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nasiha.Models;
using Nasiha.Resources;
using Nasiha.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nasiha.Controllers
{
    [Authorize]
    public class AdvicesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Advices
        public ActionResult Index()
        {
            var currentUser = _context.Users.Find(User.Identity.GetUserId());
            var siteDomain = ConfigurationManager.AppSettings["SiteDomain"].ToString();

            AdvicesVM viewModel = new AdvicesVM
            {
                User = currentUser,
                SiteDomain = siteDomain
            };

            return View(viewModel);
        }

        [AllowAnonymous]
        [Route("{nickname}")]
        public ActionResult New(string nickname)
        {
            // get model
            var receiver = _context.Users.SingleOrDefault(m => m.Nickname == nickname);
            if (receiver == null)
                return HttpNotFound();

            var viewModel = new NewAdviceVM
            {
                Advice = new Advice(),
                Receiver = receiver
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult NewAdvice(NewAdviceVM vm)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewAdviceVM
                {
                    Advice = vm.Advice,
                    Receiver = _context.Users.Find(vm.Advice.ReceiverId)
                };
                return View("New", viewModel);
            }

            // if he try to send a message to his self 
            if (User.Identity.IsAuthenticated && User.Identity.GetUserId() == vm.Advice.ReceiverId)
                return View("Advice2YourSelf");

            // user is actully Is Authenticated so we save his user name to use it later
            else if (User.Identity.IsAuthenticated) 
            {
                var user = _context.Users.Find(User.Identity.GetUserId());
                vm.Advice.Sender = user.Nickname;
            }

            vm.Advice.PublishedDate = DateTime.Now;
            _context.Advices.Add(vm.Advice);
            _context.SaveChanges();

            return View("ThankU");
        }

        // add like To Advice Or remove like
        [HttpPost]
        public void LikeOrNot(int id, bool likeOrNot)
        {
            // first case:- he press like btn To add Like
            if (likeOrNot == false)
            {
                var advice = _context.Advices.Find(id);
                advice.LikeIt = true;
            }

            // second case:- he press like btn To Remove Like
            if (likeOrNot == true)
            {
                var advice = _context.Advices.Find(id);
                advice.LikeIt = false;
            }

            _context.SaveChanges();
        }

        // pin Advice Or un pin Advice
        [HttpPost]
        public void PinOrNot(int id, bool pinOrNot)
        {
            // first case:- he press Pin btn To Pin the msg
            if (pinOrNot == false)
            {
                var advice = _context.Advices.Find(id);
                advice.PinIt = true;
            }

            // second case:- he press Pin btn To Un Pin the msg
            if (pinOrNot == true)
            {
                var advice = _context.Advices.Find(id);
                advice.PinIt = false;
            }

            _context.SaveChanges();
        }

        // Remove Message with ajax request
        [HttpPost]
        public void Remove(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var advice = _context.Advices.Find(id);

            if (advice.ReceiverId == currentUserId)
                _context.Advices.Remove(advice);
                _context.SaveChanges();
        }
    }
}