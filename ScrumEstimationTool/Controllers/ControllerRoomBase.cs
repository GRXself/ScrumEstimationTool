using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;

namespace ScrumEstimationTool.Controllers
{
    public abstract class ControllerRoomBase : Controller
    {
        protected readonly RoomList RoomList = RoomList.GetInstance();
        protected const string KeyRoomId = "RoomId";
        protected const string KeyUserName = "UserName";
    }
}