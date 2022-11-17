namespace Cliente.Models.VMs
{
    public class NationalTeamViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int bettors { get; set; }
        public CountryViewModel country { get; set; }
    }
}
