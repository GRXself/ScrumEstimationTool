using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class HostController : ControllerRoomBase
    {
        private Room _currentRoom;
        
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult<EstimationResultModel> GetCurrentEstimationResult()
        {
            InitializeProperties();
            
            if (_currentRoom is null)
            {
                return new EstimationResultModel
                {
                    Expired = true
                };
            }
            
            var estimationResult = _currentRoom.EstimationResult;
            
            return new EstimationResultModel
            {
                Estimations = estimationResult.GetEstimationResult(),
                ParticipantsName = estimationResult.GetParticipantsName(),
                Count = estimationResult.GetEstimationCount(),
            };
        }

        public IActionResult ResetEstimation()
        {
            InitializeProperties();
            
            _currentRoom.EstimationResult = new EstimationResult();
            
            return Ok();
        }

        private void InitializeProperties()
        {
            var roomId = HttpContext.Session.GetInt32("RoomId");
            _currentRoom = roomId.HasValue ? RoomList.FindRoom(roomId.Value) : null;
        }
    }
}