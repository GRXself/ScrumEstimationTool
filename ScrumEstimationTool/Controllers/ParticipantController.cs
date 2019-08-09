using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly EstimationResult _estimationResult = EstimationResult.GetInstance();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitEstimationPoint(ParticipantModel participant)
        {
            _estimationResult.AddNewEstimation(participant);
            return Ok();
        }
    }
}