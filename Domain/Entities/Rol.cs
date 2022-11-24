using Domain.Interfaces;

namespace Domain.Entities
{
    public class Rol : IEntity
    {
        public int Id { get; set; }
        public string descriptor { get; set; }
        public string descripcion { get; set; }
    }
}
