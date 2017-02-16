using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuyForU.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        [Required (ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; }
        [Required (ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}