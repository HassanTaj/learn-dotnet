using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Tour {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Discription { get; set; }
        [Display(Name ="Length In Days")]
        [Range(1,99)]
        public int Length { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
        [Display(Name ="Includes Meals")]
        public bool IncludesMeals {get; set;}
    }
}