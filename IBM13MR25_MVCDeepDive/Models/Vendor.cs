using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IBM13MR25_MVCDeepDive.Models
{
    public class VendorViewModel
    {
        [Key]
        public int VendorId { get; set; }

        [DisplayName("First-Name Last-Name")]
        [RegularExpression("[A-Za-z0-9 ]*", ErrorMessage = "Must be 10 Digit")]
        [Required]
        [StringLength(40)]
        public string FullName { get; set; }

        [DisplayName("EMail ID ")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }
        [DisplayName("Mobile No")]
        [DataType(DataType.PhoneNumber)]
       
        public string Mobile { get; set; }
        
        public int Score { get; set; }

        [Required]
        public string Password { get; set; }
        [Compare("Password",  ErrorMessage = "Confirm Password must Match")]
        public string ConfirmPassword { get; set; }


    }
}