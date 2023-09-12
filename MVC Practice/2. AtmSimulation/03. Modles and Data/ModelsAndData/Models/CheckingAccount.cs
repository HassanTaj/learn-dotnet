using ATMEntryPoint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModlsAndData.Models {
    public class CheckingAccount {

        public int Id { get; set; }

        [Required]
        //[StringLength(10,MinimumLength =6)]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}",ErrorMessage ="Account # must be between 6 and 10")]
        [Display(Name ="Account Number # ")]
        public string AccountNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string  Name {
            get { return FirstName+" "+LastName; }
        }


        [Display(Name = "Balance  ")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } // go to controler

    }
}