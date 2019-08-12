using System.Collections.Generic;
using System.Linq;
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
            var participantsInAscendingOrder = _participants.OrderBy(p => p.PersonalEstimation).ToList();
            participantsInAscendingOrder.ForEach(p => s += p.Name + ": " + p.PersonalEstimation + "; ");
            return s.Trim();
        }

        public string GetEstimationResult()
        {
            return ToString();
        }

        public string GetParticipantsName()
        {
            var s = "";
            _participants.ForEach(p => s += p.Name + "\r");
            return s.Trim();
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