using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class HomeController : ControllerRoomBase
    { 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public ActionResult<CreateRoomResultModel> CreateRoom(int roomId)
        {
            var room = RoomList.FindRoom(roomId);

            if (!(room is null))
            {
                return new CreateRoomResultModel()
                {
                    ExistRoom = true
                };
            }
            
            RoomList.CreateRoom(roomId);
            
            HttpContext.Session.SetInt32(KeyRoomId, roomId);
            Response.Cookies.Append(KeyRoomId, roomId.ToString());
            
            return new CreateRoomResultModel();
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

            return new JoinRoomResultModel()
            {
                ExistRoom = true
            };
        }
    }
}