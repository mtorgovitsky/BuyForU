using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuyForU.Models
{
    public class User
    {
        public int ID { get; set; }

        //[Required]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be from 3 to 20")]
        public string FirstName { get; set; }

        //[StringLength(20, MinimumLength = 5, ErrorMessage = "Last Name must be from 5 to 20")]
        public string LastName { get; set; }

        //[Required (ErrorMessage = "The Birth Date is obligatory")]
        public DateTime BirthDate { get; set; }

        //[Required(ErrorMessage = "The Email is obligatory")]
        //[Remote("EmailValidation", "Account", ErrorMessage = "{0} already has an account, please enter a different email address.")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        //[Required (ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }
    }
}