using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Api.Models;

namespace ScrumEstimationTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerRoomBase
    {
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = RoomList.FindRoom(id);

            if (room is null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpPost]
        public ActionResult<Room> CreateRoom(Room room)
        {
            var historyRoom = RoomList.FindRoom(room.Id);

            if (!(historyRoom is null))
            {
                return BadRequest();
            }

            RoomList.AddRoom(room);

            HttpContext.Session.SetInt32(KeyRoomId, room.Id);

            return CreatedAtAction(nameof(GetRoom), new {id = room.Id}, room);
        }

        [HttpPut("{id}")]
        public IActionResult ResetRoom(int id)
        {
            var room = RoomList.FindRoom(id);

            if (room is null)
            {
                return NotFound();
            }

            room.Participants = new List<Participant>();

            return NoContent();
        }
    }
}