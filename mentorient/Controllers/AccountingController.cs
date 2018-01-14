using System.Linq;
using System.Net.Mime;
using mentorient.Data;
using mentorient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace mentorient.Controllers
{
    public class AccountingController : Controller
    {
        private ApplicationDbContext _context;

        public AccountingController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var entries = _context.Entries.ToList();

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
    }
}