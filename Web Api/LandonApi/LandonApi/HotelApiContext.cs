using LandonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi {
    public class HotelApiContext:DbContext {
        public HotelApiContext(DbContextOptions<HotelApiContext> options):base(options) {

        }

        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
