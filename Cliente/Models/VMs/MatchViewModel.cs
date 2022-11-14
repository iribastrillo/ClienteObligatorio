using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Models.VMs
{
    public class MatchViewModel
    {
        public int homeId { get; set; }
        public int awayId { get; set; }
        public int matchResultId { get; set; }
        public NationalTeamViewModel Home { get; set; }
        public NationalTeamViewModel Away { get; set; }
        public MatchResultViewModel MatchResultDto { get; set; }
        public DateTime matchDate { get; set; }
        public GroupStageViewModel Group { get; set; }
    }
}