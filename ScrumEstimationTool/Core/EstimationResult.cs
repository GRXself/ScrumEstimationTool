using System.Collections.Generic;

namespace ScrumEstimationTool.Core
{
    public class EstimationResult
    {
        private readonly List<int> _estimationPoints = new List<int>();
        
        private static EstimationResult _estimationResult = new EstimationResult();

        private EstimationResult()
        {
        }

        public static EstimationResult GetInstance()
        {
            return _estimationResult;
        }

        public static void ResetEstimationResult()
        {
            _estimationResult = new EstimationResult();
        }

        public override string ToString()
        {
            var s = "";
            _estimationPoints.ForEach(p => s += p + " ");
            return s.Trim();
        }

        public string GetEstimationResult()
        {
            return ToString();
        }

        public int GetEstimationCount()
        {
            return _estimationPoints.Count;
        }

        public void AddNewEstimation(int estimatedPoint)
        {
            _estimationPoints.Add(estimatedPoint);
        }
    }
}