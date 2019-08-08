using Microsoft.AspNetCore.Mvc;
using ScrumEstimationTool.Core;

namespace ScrumEstimationTool.Controllers
{
    public class HostController : Controller
    {
        private readonly EstimationResult _estimationResult = EstimationResult.GetInstance();
        
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult<string> GetCurrentEstimationResult()
        {
            return _estimationResult.GetEstimationResult();
        }

        public void ResetEstimation()
        {
            EstimationResult.ResetEstimationResult();
        }
    }
}