using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models {
    public class BookingForm {

        [Required]
        [Display(Name ="startAt",Description ="Booking start time")]
        public DateTimeOffset? StartAt { get; set; }

        [Required]
        [Display(Name = "endAt", Description = "Booking end time")]
        public DateTimeOffset? EndAt { get; set; }
    }
}
