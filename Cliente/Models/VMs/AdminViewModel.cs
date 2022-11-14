using Cliente.Models.DTOs;

namespace Cliente.Models.VMs
{
    public class AdminViewModel
    {
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public string Group { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Bettors { get; set; }
    }
}
