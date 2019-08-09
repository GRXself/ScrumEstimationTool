using System.Collections.Generic;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Core
{
    public class EstimationResult
    {
        private readonly List<ParticipantModel> _participants = new List<ParticipantModel>();
        
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
            _participants.ForEach(p => s += p.Name + ": " + p.PersonalEstimation + "; ");
            return s.Trim();
        }

        public string GetEstimationResult()
        {
            return ToString();
        }

        public int GetEstimationCount()
        {
            return _participants.Count;
        }

        public void AddNewEstimation(ParticipantModel participant)
        {
            _participants.Add(participant);
        }
    }
}