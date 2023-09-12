using LandonApi.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Services
{
    public class DefaultDateLogicService : IDateLogicService
    {
        private readonly HotelOptions _hotelOptions;

        public DefaultDateLogicService(IOptions<HotelOptions> optionsAccessor)
        {
            _hotelOptions = optionsAccessor.Value;
        }

        public TimeSpan GetMinimumStay()
            => TimeSpan.FromHours(_hotelOptions.MinimumStayHours);

        public DateTimeOffset FurthestPossibleBooking(DateTimeOffset now)
            => AlignStartTime(now) + TimeSpan.FromDays(_hotelOptions.MaxAdvanceBookingDays);

        public DateTimeOffset AlignStartTime(DateTimeOffset original)
        {
            var dateInServerOffset = original.ToOffset(
                TimeSpan.FromHours(_hotelOptions.UtcOffsetHours));
            return new DateTimeOffset(
                dateInServerOffset.Year,
                dateInServerOffset.Month,
                dateInServerOffset.Day,
                12, 00, 00,
                dateInServerOffset.Offset);
        }

        public IEnumerable<BookingRange> GetAllSlots(
            DateTimeOffset start,
            DateTimeOffset? end = null)
        {
            var newStart = AlignStartTime(start);

            while (true)
            {
                if (end != null && newStart >= end) yield break;

                var newEnd = newStart.Add(TimeSpan.FromHours(_hotelOptions.MinimumStayHours));
                yield return new BookingRange
                {
                    StartAt = newStart,
                    EndAt = newEnd
                };

                newStart = newEnd;
            }
        }

        public bool DoesConflict(BookingRange b, DateTimeOffset start, DateTimeOffset end)
        {
            return
                // Bookings with the same start or end time
                (b.StartAt == start || b.EndAt == end)

                // Bookings overlapping the start of our window of interest
                || (b.StartAt < start && b.EndAt > start)

                // Bookings overlapping the end of our window of interest
                || (b.StartAt < end && b.EndAt > end)

                // Bookings during our window of interest
                || (b.StartAt > start && b.EndAt < end);
        }
    }
}
