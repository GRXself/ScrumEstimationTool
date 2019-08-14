using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly RoomList _roomList = RoomList.GetInstance();
        
        private Room _currentRoom;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitEstimationPoint(ParticipantModel participant)
        {
            InitializeProperties();
            
            var estimationResult = _currentRoom.EstimationResult;
            
            estimationResult.AddNewEstimation(participant);
            return Json(new {
                Expired = false,
            });
        }
        
        private void InitializeProperties()
        {
            var roomId = HttpContext.Session.GetInt32("RoomId");
            _currentRoom = roomId.HasValue ? _roomList.FindRoom(roomId.Value) : null;
        }
    }
}