using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LandonApi.Controllers {
    [Route("/[controller]")]
    public class InfoController : Controller {
        private HotelInfo _hotelInfo;
        public InfoController(IOptions<HotelInfo> hotelInfoAccessor) {
            _hotelInfo = hotelInfoAccessor.Value;
        }

        [HttpGet(Name =nameof(GetInfo))]
        public IActionResult GetInfo() {
            _hotelInfo.Href = Url.Link(nameof(GetInfo), null);

            return Ok(_hotelInfo);
        }
    }
}