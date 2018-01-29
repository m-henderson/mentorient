using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mentorient.Models.Accounting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault.Models;

namespace mentorient.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Tenant> Tenants { get; set; }
            = new List<Tenant>();

        public ICollection<Entry> AccountingEntries { get; set; }
            = new List<Entry>();

        public ICollection<Contact> Contacts { get; set; }
            = new List<Contact>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
