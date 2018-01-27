using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mentorient.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<City> Cities { get; set; }
            = new List<City>();
        public ICollection<State> States { get; set; }
            = new List<State>();

        public string ZipCode { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }

    }
}
