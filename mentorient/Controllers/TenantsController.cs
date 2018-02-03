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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index(string searchString)
        {
            var userId = _userManager.GetUserId(User);
            var tenants = _context.Users.Include(usr => usr.Tenants)
                .Single(usr => usr.Id == userId)
                .Tenants;

            if (!String.IsNullOrEmpty(searchString))
            {
                tenants = tenants.Where(t => t.FirstName.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) >= 0
                                || t.LastName.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                if (!tenants.Any())
                {
                    ViewData["Message"] = "No tenants found.";
                }
            }
            return View(tenants);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Save(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                _context.Users.Single(usr => usr.Id == userId).Tenants.Add(tenant);
                _context.Tenants.Add(tenant);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("New");
        }

        public IActionResult Delete(int? id)
        {
            var tenant = _context.Tenants.SingleOrDefault(t => t.Id == id);
            _context.Remove(tenant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            var tenant = _context.Tenants.SingleOrDefault(t => t.Id == id);
            return View(tenant);
        }
    }
}