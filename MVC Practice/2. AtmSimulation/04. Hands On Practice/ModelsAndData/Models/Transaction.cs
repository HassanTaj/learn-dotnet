using ModlsAndData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsAndData.Models {
    public class Transaction {

        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public int CheckingAccountId { get; set; }// this will corospond to a foregin key in the database
        // this is Navigation Property
        public virtual CheckingAccount CheckingAccount { get; set; } 
        //  by adding this navigation property entity framework will know this to set this as a foregin key
        // also add navigation property to checking account
    }
}