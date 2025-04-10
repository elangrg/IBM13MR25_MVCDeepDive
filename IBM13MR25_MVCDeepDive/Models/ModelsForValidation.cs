using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Please Enter Email Address")]
        //[Required(ErrorMessageResourceName = "Demo", ErrorMessageResourceType = typeof(ErrorMessageProvider))]
        //[Required(ErrorMessageResourceName = "UserNameR", ErrorMessageResourceType =typeof(Resource1))]
        [Display(Name = "Enter User Name")]
        [EmailValidator(ErrorMessage = "Please Enter Correct Email Address")]
        //[Remote("IsUserNameExist", "Home", ErrorMessage = "User name already exist")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }

        [Display(Name = "City")]
        public City City { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]

        [Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string MobileNo { get; set; }

        [MustBeTrue(ErrorMessage = "Please Accept the Terms & Conditions")]
        public bool TermsAccepted { get; set; }
    }

    public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "checkbox", ErrorMessage = this.ErrorMessage } };
        }


    }

    public class MustBeSelected : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            if (value == null || (int)value == 0)
                return false;
            else
                return true;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "dropdown", ErrorMessage = this.ErrorMessage } };
        }
    }

    public class Country
    {
        [MustBeSelected(ErrorMessage = "Please Select Country")]
        public int? ID { get; set; }
        public string Name { get; set; }

    }

    public class City
    {
        [MustBeSelected(ErrorMessage = "Please Select City")]
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? Country { get; set; }
    }


    public class EmailValidator : RegularExpressionAttribute
    {
        public EmailValidator()
            : base(".+@.+\\..+")
        {

        }

    }



    public static class ErrorMessageProvider
    {
        static ErrorMessageProvider()
        {
            Demo = "user name req -- -- ";
        }


        public static string Demo { get; set; }

    }
}