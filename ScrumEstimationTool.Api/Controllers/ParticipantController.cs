using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Api.Models;

namespace ScrumEstimationTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerRoomBase
    {
        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<Participant>> GetAllParticipantsByRoomId(int roomId)
        {
            var room = RoomList.FindRoom(roomId);

            if (room is null)
            {
                return NotFound();
            }

            return room.Participants;
        }

        [HttpPost("{roomId}")]
        [HttpPut("{roomId}")]
        public ActionResult SubmitEstimation(int roomId, Participant participant)
        {
            var room = RoomList.FindRoom(roomId);

            if (room is null)
            {
                return NotFound();
            }

            var participants = room.Participants;

            var historyParticipant = participants.FirstOrDefault(p => p.Name.Equals(participant.Name));

            if (historyParticipant is null)
            {
                participants.Add(participant);

                return Ok();
            }

            historyParticipant.Estimation = participant.Estimation;

            return Ok();
        }
    }
}