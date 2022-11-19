using System;

namespace Cliente.Models.VMs
{
    public class MatchViewModel
    {
        public int homeId { get; set; }
        public int awayId { get; set; }
        public string homeCountry { get; set; }
        public string awayCountry { get; set; }
        public MatchResultViewModel? MatchResultDto { get; set; }
        public DateTime matchDate { get; set; }
        public GroupStageViewModel Group { get; set; }
    }
}