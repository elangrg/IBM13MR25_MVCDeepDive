using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBM13MR25_MVCDeepDive.Models
{
    [MetadataType(typeof(CustomerValidationExt))]
    public partial class Customer
    {



    }


    public partial class CustomerValidationExt
    {
        [Required(ErrorMessage ="Customer Full Name is Required")]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
    
    }





}