using LandonApi.Infrastructure;
using LandonApi.Models;
using LandonApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LandonApi.Controllers {
    [Route("/[controller]")]
    public class RoomsController : Controller {

        private readonly IRoomService _roomService;
        private readonly IOpeningService _openingService;
        public readonly IBookingService _bookingService;
        public readonly IDateLogicService _dateLogicService;
        private readonly PagingOptions _defaultPagingOptions;
        public RoomsController(
            IRoomService roomService,
            IOpeningService openingService, 
            IDateLogicService dateLogicService,
            IBookingService bookingService,
            IOptions<PagingOptions> defaultPagingOptions) {
            _roomService = roomService;
            _openingService = openingService;
            _defaultPagingOptions = defaultPagingOptions.Value;
            _dateLogicService = dateLogicService;
            _bookingService = bookingService;
        }

        [HttpGet(Name = nameof(GetAllRoomsAsync))]
        public async Task<IActionResult> GetAllRoomsAsync(
            [FromQuery] PagingOptions pagingOptions,
            [FromQuery] SortOptions<Room, RoomEntity> sortOptions,
            [FromQuery] SearchOptions<Room, RoomEntity> searchOptions,
            CancellationToken cts) {

            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var rooms = await _roomService.GetRoomsAsync(
                pagingOptions,
                sortOptions,
                searchOptions,
                cts);  //Ok(_roomService.ToList());

            var collection = PagedCollection<Room>.Create<RoomsResponse>(
                Link.ToCollection(nameof(GetAllRoomsAsync)),
                rooms.Items.ToArray(),
                rooms.TotalSize,
                pagingOptions);

            collection.Openings = Link.ToCollection(nameof(GetRoomOpeningsAsync));

            collection.RoomsQuery = FormMetadata.FromResource<Room>(
                Link.ToForm(nameof(GetAllRoomsAsync),null,Link.GetMethod,
                Form.QueryRelation));

            return Ok(collection);
        }

        [HttpGet("openings",Name = nameof(GetRoomOpeningsAsync))]
        public async Task<IActionResult> GetRoomOpeningsAsync([FromQuery] PagingOptions pagingOptions, CancellationToken cts) {

            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var openings = await _openingService.GetOpeningsAsync(pagingOptions, cts);
            var collection = PagedCollection<Opening>.Create(
                Link.ToCollection(nameof(GetRoomOpeningsAsync)),
                openings.Items.ToArray(),
                openings.TotalSize,
                pagingOptions);

            return Ok(collection);
        }

        [HttpPost("{roomId}/bookings",Name =nameof(CreateBookingForRoomAsync))]
        public async Task<IActionResult> CreateBookingForRoomAsync(Guid roomId,
            [FromBody] BookingForm bookingForm,
            CancellationToken cts) {
            if (!ModelState.IsValid) return BadRequest(new ApiError(ModelState));

            var room = await _roomService.GetRoomAsync(roomId, cts);
            if (room == null) return NotFound();

            var minimumStay = _dateLogicService.GetMinimumStay();

            bool tooShort = (bookingForm.EndAt.Value - bookingForm.StartAt.Value) < minimumStay;
            if (tooShort) return BadRequest(new ApiError($"The minimum booking duration is {minimumStay.TotalHours}"));

            var conflictedSlots = await _openingService.GetConflictingSlots(roomId, bookingForm.StartAt.Value, bookingForm.EndAt.Value);

            if (conflictedSlots.Any()) return BadRequest(new ApiError("This time conflicts with an existing booking"));

            // get the user id (TODO)
            var userId = Guid.NewGuid();

            var bookingId = await _bookingService.CreateBookingAsync(userId, roomId, bookingForm.StartAt.Value, bookingForm.EndAt.Value);

            return Created(Url.Link(nameof(BookingsController.GetBookingById),new { bookingId}),null);
        }


        [HttpGet("{roomId}",Name = nameof(GetRoomByIdAsync))]
        public async Task<IActionResult> GetRoomByIdAsync(Guid roomId,CancellationToken cts) {

            var room = await _roomService.GetRoomAsync(roomId, cts);
            if (room == null) return NotFound();


            return Ok(room);
        }
    }
}