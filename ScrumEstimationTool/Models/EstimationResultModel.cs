using System.Collections.Generic;

namespace ScrumEstimationTool.Models
{
    public class EstimationResultModel
    {
        public List<string> Estimations { get; set; }
        
        public string ParticipantsName { get; set; }
        
        public int Count { get; set; }
        
        public bool Expired { get; set; }
    }
}