using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuyForU.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "שם פרטי שדה חובה")]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "שם משפחה שדה חובה")]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "נא לכתוב תאריך לידה")]
        [DisplayName("תאריך לידה")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1900", "01/01/2014", ErrorMessage = "שימוש באתר מגיל בר מצווה בלבד")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "מייל שדה חובה")]
        [DisplayName("אימייל")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required (ErrorMessage = "נא לכתוב שם משתמש")]
        [DisplayName("שם משתמש")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required (ErrorMessage = "נא לכתוב סיסמה")]
        [DisplayName("סיסמה")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("אימות סיסמא")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "סיסמה ושם משתמש אינם זהים")]
        public string ConfirmPassword { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Product> Products { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Product> ProductsToSell { get; set; }
    }
}