using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models
{
    public class OpeningEntity : BookingRange
    {
        public Guid RoomId { get; set; }

        public int Rate { get; set; }
    }
}
