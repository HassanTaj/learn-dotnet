using LandonApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LandonApi.Services {
    public interface IBookingService {
        Task<Booking> GetBookingAsync(Guid bookingId);

        Task<Guid> CreateBookingAsync(
            Guid userId,
            Guid roomId,
            DateTimeOffset startAt,
            DateTimeOffset endAt);

        Task DeleteBookingAsync(Guid bookingId, CancellationToken cts);
    }
}
