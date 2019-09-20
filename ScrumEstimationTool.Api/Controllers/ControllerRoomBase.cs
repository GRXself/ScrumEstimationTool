using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Api.Core;

namespace ScrumEstimationTool.Api.Controllers
{
    public abstract class ControllerRoomBase : Controller
    {
        protected readonly RoomList RoomList = RoomList.GetInstance();
        protected const string KeyRoomId = "RoomId";
        protected const string KeyUserName = "UserName";
        protected const string KeyUserEstimation = "UserEstimation";
    }
}