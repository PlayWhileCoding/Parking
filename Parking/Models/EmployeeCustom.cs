using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Parking
{
    [MetadataType(typeof(EmployeeCustom))]
    public partial class Employee
    {

    }
    public class EmployeeCustom
    {

        public int EmployeeId { get; set; }

        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastNanem { get; set; }
        [Display(Name = "Age")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "SSN")]
        public string NSS { get; set; }

        [Display(Name = "House Provider affiliation #")]
        public string Infonavit { get; set; }
    }
}