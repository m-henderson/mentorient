using System.Linq;
using System.Net.Mime;
using mentorient.Data;
using mentorient.Models;
using mentorient.Models.Accounting;
using mentorient.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace mentorient.Controllers
{
    public class AccountingController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public AccountingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var entries = _context.Users.Include(usr => usr.AccountingEntries)
                .Single(usr => usr.Id == userId)
                .AccountingEntries;

            return View(entries);
        }

        public IActionResult Create()
        {
            var vm = new AccountingEntryViewModel();
            vm.Tenants = _context.Tenants.Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.FirstName + " " + a.LastName
                })
                .ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Save(Entry accountingEntry)
        {
            var userId = _userManager.GetUserId(User);
            var tenantId = accountingEntry.TenantId;
            var tenant = _context.Tenants.SingleOrDefault(t => t.Id == tenantId);
            var tenantName = tenant.FirstName + " " + tenant.LastName;
            accountingEntry.TenantName = tenantName;

            _context.Users.Single(usr => usr.Id == userId).AccountingEntries.Add(accountingEntry);

            _context.Entries.Add(accountingEntry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}