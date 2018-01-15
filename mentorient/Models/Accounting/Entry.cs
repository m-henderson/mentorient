using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mentorient.Models.Accounting
{
    public class Entry
    {

        public int Id { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DatePaid { get; set; }
        public string Description { get; set; }
        public double AmountDue { get; set; }
        public double AmountPaid { get; set; }
        public double AmountRemaining { get; set; }
        public virtual Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        public string Comments { get; set; }
        public string TenantName { get; set; }
    }
}