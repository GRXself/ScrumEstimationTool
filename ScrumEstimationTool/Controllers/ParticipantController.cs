using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;

namespace ScrumEstimationTool.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly EstimationResult _estimationResult = EstimationResult.GetInstance();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitEstimationPoint(int estimationPoint)
        {
            _estimationResult.AddNewEstimation(estimationPoint);
            return Ok();
        }
    }
}