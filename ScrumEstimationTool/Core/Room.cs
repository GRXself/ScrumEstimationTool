using System;

namespace ScrumEstimationTool.Core
{
    public class Room
    {
        public int Id { get; set; }
        
        public EstimationResult EstimationResult { get; set; }
        
        public DateTime CreateTime { get; set; }
        
        public DateTime LastUseTime { get; set; }

        public Room(int roomId)
        {
            Id = roomId;
            EstimationResult = new EstimationResult();
            CreateTime = DateTime.Now;
            LastUseTime = CreateTime;
        }
    }
}