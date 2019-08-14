using System.Collections.Generic;
using System.Linq;
using ScrumEstimationTool.Models;

namespace ScrumEstimationTool.Core
{
    public class EstimationResult
    {
        private readonly List<ParticipantModel> _participants = new List<ParticipantModel>();

        public List<string> GetEstimationResult()
        {
            var estimations = new List<string>();
            var participantsInAscendingOrder = _participants.OrderBy(p => p.PersonalEstimation).ToList();
            participantsInAscendingOrder.ForEach(p => estimations.Add(p.Name + ": " + p.PersonalEstimation));
            return estimations;
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