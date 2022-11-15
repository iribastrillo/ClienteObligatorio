namespace Cliente.Models.DTOs
{
    public class NationalTeamDTO
    {
        public CountryDTO Country { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Bettors { get; set; }
    }
}