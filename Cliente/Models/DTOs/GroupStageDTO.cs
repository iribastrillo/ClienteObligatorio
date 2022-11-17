namespace Cliente.Models.DTOs
{
    public class GroupStageDTO
    {
        public string Group { get; set; }
        public int Id { get; set; }

        public GroupStageDTO (int id, string group)
        {
            Group = group;
            Id = id;
        }
        public GroupStageDTO (string group)
        {
            Group = group;
        }
    }

}
