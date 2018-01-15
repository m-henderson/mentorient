using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mentorient.Models.Accounting;

namespace mentorient.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Entry>  Entries { get; set; }
        = new List<Entry>();

        
    }
}
