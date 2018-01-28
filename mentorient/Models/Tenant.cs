using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mentorient.Models.Accounting;

namespace mentorient.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        public string Email { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Date of birth required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }

        [DisplayName("Zip code")]
        [Required(ErrorMessage = "Zip code required")]
        public string ZipCode { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "State required")]
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Entry>  Entries { get; set; }
        = new List<Entry>();

        
    }
}
