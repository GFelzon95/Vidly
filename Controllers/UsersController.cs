using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UsersController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        public UsersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            var viewModel = new UsersListViewModel()
            {
                Users = _context.Users.ToList(),
                //Roles = _context.Roles.ToList()
            };

            return View("List", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var rolesList = _context.Roles.ToList();
            var user = _context.Users.SingleOrDefault(u => u.SiteId == id);

            var viewModel = new UsersEditViewModel() {
                SiteId = user.SiteId,
                Phone = user.Phone,
                DrivingLicense = user.DrivingLicense,
                Email = user.Email,
                UserRole = "",

                Roles = rolesList
            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(UsersEditViewModel user)
        {
            if (!ModelState.IsValid)
            {
                var rolesList = _context.Roles.ToList();

                var viewModel = new UsersEditViewModel
                {
                    SiteId = user.SiteId,
                    Phone = user.Phone,
                    DrivingLicense = user.DrivingLicense,
                    Email = user.Email,
                    UserRole = user.UserRole,

                    Roles = rolesList
                };

                return View("Edit", viewModel);
            }

            var userInDb = _context.Users.SingleOrDefault(u => u.SiteId == user.SiteId);

            userInDb.Phone = user.Phone;
            userInDb.DrivingLicense = user.DrivingLicense;
            userInDb.Email = user.Email;

            var roles = this.UserManager.GetRoles(userInDb.Id);
            this.UserManager.RemoveFromRoles(userInDb.Id,roles.ToArray()); //delete previous role
            this.UserManager.AddToRoles(userInDb.Id, user.UserRole);       //assign new role

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
        
    }
}