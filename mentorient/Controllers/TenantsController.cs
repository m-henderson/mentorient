using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using mentorient.Data;
using mentorient.Models;
using mentorient.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace mentorient.Controllers
{
    [Authorize]
    public class TenantsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        public TenantsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var loggedInUser = _userManager.GetUserId(User);
            var tenants = _context.Tenants.ToList().Where(usr => usr.OwnerId == loggedInUser);
            
            return View(tenants);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Save(Tenant tenant)
        {

            tenant.OwnerId = _userManager.GetUserId(User);

            _context.Tenants.Add(tenant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var tenant = _context.Tenants.SingleOrDefault(t => t.Id == id);
            _context.Remove(tenant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}