using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mentorient.Models.ViewModels
{
    public class AccountingEntryViewModel
    {
        public int Id { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DatePaid { get; set; }
        public string Description { get; set; }
        public double AmountDue { get; set; }
        public double AmountPaid { get; set; }
        public double AmountRemaining { get; set; }
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        public string Comments { get; set; }
        public List<SelectListItem> Tenants { get; set; } = new List<SelectListItem>();

    }
}
