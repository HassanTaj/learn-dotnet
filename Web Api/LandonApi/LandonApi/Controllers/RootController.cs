using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LandonApi.Controllers {
    [Route("/")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RootController : Controller {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot() {

            //var res = new{
            //    href = Url.Link(nameof(GetRoot), null),
            //    rooms = new {
            //        href = Url.Link(nameof(RoomsController.GetRooms), null)
            //    },
            //    info = new { href = Url.Link(nameof(InfoController.GetInfo), null) }
            //};

            var res = new RootResponse {
                Self = Link.To(nameof(GetRoot)),
                Rooms = Link.ToCollection(nameof(RoomsController.GetAllRoomsAsync)),
                Info = Link.To(nameof(InfoController.GetInfo))
            };

            return Ok(res);
        }
    }
}