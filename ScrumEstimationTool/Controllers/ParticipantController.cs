using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class ParticipantController : ControllerRoomBase
    {
        private Room _currentRoom;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitEstimationPoint(ParticipantModel participant)
        {
            InitializeProperties();
            
            HttpContext.Session.SetString(KeyUserName, participant.Name);
            Response.Cookies.Append(KeyUserName, participant.Name);
            
            var estimationResult = _currentRoom.EstimationResult;
            
            estimationResult.AddNewEstimation(participant);
            return Json(new {
                Expired = false,
            });
        }
        
        public ActionResult<JoinRoomResultModel> JoinRoom(int roomId)
        {
            var room = RoomList.FindRoom(roomId);

            if (room is null)
            {
                return new JoinRoomResultModel();
            }
            
            HttpContext.Session.SetInt32(KeyRoomId, roomId);
            Response.Cookies.Append(KeyRoomId, roomId.ToString());

            return View("~/Views/Participant/Index.cshtml");
        }
        
        private void InitializeProperties()
        {
            var roomId = HttpContext.Session.GetInt32("RoomId");
            _currentRoom = roomId.HasValue ? RoomList.FindRoom(roomId.Value) : null;
        }
    }
}