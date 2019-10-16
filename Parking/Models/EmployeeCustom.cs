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
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Field cannot be empty")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string LastNanem { get; set; }

        [Display(Name = "Age")]        
        [Required(ErrorMessage = "Field cannot be empty")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string City { get; set; }

        [Display(Name = "State")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string State { get; set; }

        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Country { get; set; }

        [Display(Name = "SSN")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string NSS { get; set; }

        [Display(Name = "House Provider affiliation #")]        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Infonavit { get; set; }
    }
}