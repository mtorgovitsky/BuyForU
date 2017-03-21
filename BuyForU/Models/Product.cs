using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuyForU.Models
{
    public enum State
    {
        ForSale,
        InCard,
        Sold
    }

    public class Product
    {

        public int ID { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerID { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        [Required(ErrorMessage = "נא לכתוב כותרת")]
        [DisplayName("כותרת")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "נא לכתוב תאור קצר")]
        [DisplayName("תאור קצר")]
        [StringLength(500)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "נא לכתוב תאור מפורט")]
        [DisplayName("תאור מפורט")]
        [StringLength(4000)]
        public string LongDescription { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        [DisplayName("תאריך הוספה")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "נא לכתוב מחיר")]
        [Range(0.01, 50000)]
        [DisplayName("מחיר")]
        public decimal Price { get; set; }

        [DisplayName("תמונה מס' 1")]
        public byte[] Picture1 { get; set; }

        [DisplayName("תמונה מס' 2")]
        public byte[] Picture2 { get; set; }

        [DisplayName("תמונה מס' 3")]
        public byte[] Picture3 { get; set; }

        [Required]
        public State Status { get; set; }

        [NotMapped]
        public bool IsInCard { get; set; }

        public virtual User User { get; set; }

        public virtual User Owner { get; set; }
    }
}