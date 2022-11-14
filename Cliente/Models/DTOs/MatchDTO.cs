using System;

namespace Cliente.Models.DTOs
{
    public class MatchDTO
    {
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
