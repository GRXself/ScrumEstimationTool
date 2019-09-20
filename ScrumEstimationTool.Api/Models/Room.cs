using System;
using System.Collections.Generic;

namespace ScrumEstimationTool.Api.Models
{
    public class Room
    {
        public int Id { get; set; }

        public List<Participant> Participants { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUseTime { get; set; }

        public Room(int roomId)
        {
            Id = roomId;
            Participants = new List<Participant>();
            CreateTime = DateTime.Now;
            LastUseTime = CreateTime;
        }
    }
}