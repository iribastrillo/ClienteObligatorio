using Domain.VO;

namespace Cliente.Models.VMs
{
    public class MatchResultViewModel
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public int matchId { get; set; }
        public int goalsH { get; set; }
        public int goalsA { get; set; }
        public int yellowCardsH { get; set; }
        public int yellowCardsA { get; set; }
        public int redCardsH { get; set; }
        public int redCardsA { get; set; }
        public int directRedCardsH { get; set; }
        public int directRedCardsA { get; set; }
        public int pointsHome { get; set; }
        public int pointsAway { get; set; }
    }
}