using LandonApi.Models;
using LandonApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LandonApi.Controllers {
    [Route("/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService) {
            _bookingService = bookingService;
        }

        // TODO: authorization
        [HttpGet("{bookingId}", Name = nameof(GetBookingById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Booking>> GetBookingById(Guid bookingId) {
            var booking = await _bookingService.GetBookingAsync(bookingId);
            if (booking == null) return NotFound();

            return booking;
        }

        // DELETE /bookings/{bookingId}
        [HttpDelete("{bookingId}", Name = nameof(DeleteBookingByIdAsync))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteBookingByIdAsync(Guid bookingId) {
            // TODO: Authorize that the user is allowed to do this!
            await _bookingService.DeleteBookingAsync(bookingId);
            return NoContent();
        }
    }
}