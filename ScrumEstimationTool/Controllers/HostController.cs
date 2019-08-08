using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Controllers
{
    public class HostController : Controller
    {
        private readonly EstimationResult _estimationResult = EstimationResult.GetInstance();
        
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult<EstimationResultModel> GetCurrentEstimationResult()
        {
            return new EstimationResultModel
            {
                EstimationResult = _estimationResult.GetEstimationResult(),
                Count = _estimationResult.GetEstimationCount()
            };
        }

        public IActionResult ResetEstimation()
        {
            EstimationResult.ResetEstimationResult();
            return Ok();
        }
    }
}